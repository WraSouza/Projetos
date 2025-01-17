﻿using MediatR;
using Projects.Application.Models.ViewModels;
using Projects.Domain.Repositories;

namespace Projects.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler(IProjectRepository repository) : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            List<ProjectViewModel> viewModel = [];

            //throw new NotImplementedException();
            var projects = await repository.GetAllProjectsAsync();

            foreach(var project in projects)
            {
                ProjectViewModel model = new ProjectViewModel(project.ProjectName);

                viewModel.Add(model);
            }

            return viewModel;
            
        }
    }
}
