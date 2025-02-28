using DevFreela.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
