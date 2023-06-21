﻿using TaskReporter.Business.DTO;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Business.Interfaces;

public interface IWeeklyReportService
{
    WeeklyReportDTO GetById(int id);
    void Insert(WeeklyReportCreateDTO entity);
    void Delete(int id);
    void Update(int id, WeeklyReportCreateDTO entity);
    List<WeeklyReport> GetAll();

}