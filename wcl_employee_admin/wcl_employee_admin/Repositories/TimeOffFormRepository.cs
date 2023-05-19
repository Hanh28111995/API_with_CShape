using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;

namespace wcl_employee_admin.Repositories
{
    public class TimeOffFormRepository : ITimeOffFormRepository
    {
        private readonly FormContext _context;
        private readonly IMapper _mapper;

        public TimeOffFormRepository(FormContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TimeOffFormModal> getFormAsync(int ReferenceID)
        {
            var form = await _context.TimeOffForms!.FindAsync(ReferenceID);
            return _mapper.Map<TimeOffFormModal>(form);
        }

        public async Task<List<TimeOffFormModal>> getAllFormsAsync()
        {
            var forms = await _context.TimeOffForms!.ToListAsync();
            return _mapper.Map<List<TimeOffFormModal>>(forms);
        }

        public async Task<int> AddFormAsync(TimeOffFormModal model)
        {
            var newForm = _mapper.Map<TimeOffForm>(model);
            _context.TimeOffForms!.Add(newForm);
            await _context.SaveChangesAsync();
            return newForm.ReferenceID;
        }

        public async Task DeleteFormAsync(int ReferenceID)
        {
            var deletedForm = _context.TimeOffForms!.SingleOrDefault(x => x.ReferenceID == ReferenceID);
            if (deletedForm != null)
            {
                _context.TimeOffForms!.Remove(deletedForm);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateFormAsync(int ReferenceID, TimeOffFormModal model)
        {
            if (ReferenceID == model.ReferenceID)
            {
                var updateForm = _mapper.Map<TimeOffForm>(model);
                _context.TimeOffForms!.Update(updateForm);
                await _context.SaveChangesAsync();
            }
        }
    }
}
