﻿using DevFreela.Core.Entities;


namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task <Project> GetProjectByIdAsync(int id);
    }

}
