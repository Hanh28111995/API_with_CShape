using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.TimeOffRepository
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

        public async Task<TimeOffFormModal> getFormAsync(int ID)
        {
            var form = await _context.TimeOffForms!.FindAsync(ID);
            return _mapper.Map<TimeOffFormModal>(form);
        }

        public async Task<List<TimeOffFormModal>> getGroupFormsAsync(string group)
        {
            var forms = await _context.TimeOffForms!.ToListAsync();

            return _mapper.Map<List<TimeOffFormModal>>(forms);
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
            return newForm.ID;
        }

        public async Task DeleteFormAsync(int ID)
        {
            var deletedForm = _context.TimeOffForms!.SingleOrDefault(x => x.ID == ID);
            if (deletedForm != null)
            {
                _context.TimeOffForms!.Remove(deletedForm);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ResultFeedBack> UpdateFormAsync(TimeOffFormModal model)
        {
            var updateForm = _mapper.Map<TimeOffForm>(model);
            var result_Update = _context.TimeOffForms!.Update(updateForm);
            var result_saveChange = await _context.SaveChangesAsync();
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Edit Note Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Edit Note Fail." };
        }
    }
}
