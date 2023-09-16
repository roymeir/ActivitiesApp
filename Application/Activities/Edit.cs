using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    /// <summary>
    /// This class is used to edit an existing activity.
    /// </summary>
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            /// <summary>
            /// This method is used to edit an existing activity.
            /// Uses automapper to update all relevant fields of the activity.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);
                _mapper.Map(request.Activity, activity);
                await _context.SaveChangesAsync();
            }

        }
    }
}