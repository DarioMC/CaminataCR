USE [msdb]
GO

/****** Object:  Job [Cierre Diario]    Script Date: 17/6/2017 09:10:07: AM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [Database Maintenance]    Script Date: 17/6/2017 09:10:07: AM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'Database Maintenance' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'Database Maintenance'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'Cierre Diario', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'Del monto total de donaciones diarias se toma un 10% que será distribuido entre los usuarios. Se tomará como método de distribución la cantidad de likes obtenidos durante el plazo de tiempo evaluado (1 día). Debe registrar en la base de datos la fecha, monto y cuenta a la cual se deben acreditar los fondos.', 
		@category_name=N'Database Maintenance', 
		@owner_login_name=N'Josue', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Monto Total donaciones 10%]    Script Date: 17/6/2017 09:10:08: AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Monto Total donaciones 10%', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=1, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'Use Caminata
Go

declare @MONTOTOTAL int
SET @MONTOTOTAL = (select SUM(MontoDonacion) from Donacion where Fecha BETWEEN Convert(Date, GETDATE()) AND CONCAT(Convert(Date, GETDATE()), '' 23:59:59'')) * 0.10
declare @ExecStr NVarchar(MAX)
SET @ExecStr = N''declare @cantLikes int
SET @cantLikes = (select Count(DISTINCT L.IdLike) Likes from Evento E left join Likes L ON L.IdEvento = E.IdEvento inner join Caminata C on E.IdCaminata = C.IdCaminata where L.Fecha BETWEEN Convert(Date, GETDATE()) AND CONCAT(Convert(Date, GETDATE()), '''' 23:59:59''''))
If (@MONTOTOTAL is not null)
Begin
INSERT CierreDiario(IdHiker, Fecha, Monto)
Select IdCreador, GETDATE(), @MONTOTOTAL*(Count(L.IdLike)/@cantLikes) from Evento E left join Likes L ON L.IdEvento = E.IdEvento inner join Caminata C on E.IdCaminata = C.IdCaminata
where L.Fecha BETWEEN Convert(Date, GETDATE()) AND CONCAT(Convert(Date, GETDATE()), '''' 23:59:59'''')
group by C.IdCreador
end''
exec sp_executesql @ExecStr, N''@MONTOTOTAL INT'', @MONTOTOTAL
go', 
		@database_name=N'Caminata', 
		@database_user_name=N'dbo', 
		@flags=4
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'Cierre Diario', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20170617, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, 
		@schedule_uid=N'26f230fa-8e45-42af-8c84-d672357f748f'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO

