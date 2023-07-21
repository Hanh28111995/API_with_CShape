using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.TimeSheetRepository
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly FormContext _context;
        private readonly IMapper _mapper;

        public TimeSheetRepository(FormContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TimeSheetModal>> getGroupFormsAsync(string group)
        {
            var forms = await _context.timeSheetForm!.ToListAsync();

            return _mapper.Map<List<TimeSheetModal>>(forms);
        }

        public async Task<TimeSheetModal> getFormAsync(int ID)
        {
            var form = await _context.timeSheetForm!.FindAsync(ID);
            return _mapper.Map<TimeSheetModal>(form);
        }

        public async Task<List<TimeSheetModal>> getAllFormsAsync()
        {
            var forms = await _context.timeSheetForm!.AsNoTracking().ToListAsync();
                
            return _mapper.Map<List<TimeSheetModal>>(forms);
        }

        public async Task<ResultFeedBack> AddFormAsync(TimeSheetModal model)
        {
            var newForm = _mapper.Map<TimeSheetForm>(model);
            _context.timeSheetForm!.Add(newForm);
            var result_saveChange = await _context.SaveChangesAsync();
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Create TimeSheet Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Create TimeSheet Fail." };

        }

        public async Task DeleteFormAsync(int ID)
        {
            var deletedForm = _context.timeSheetForm!.SingleOrDefault(x => x.ID == ID);
            if (deletedForm != null)
            {
                _context.timeSheetForm!.Remove(deletedForm);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ResultFeedBack> UpdateFormAsync(TimeSheetModal model)
        {
            var updateForm = _mapper.Map<TimeSheetForm>(model);
            _context.timeSheetForm!.Update(updateForm);
            var result_saveChange = await _context.SaveChangesAsync();
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Update Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Update Fail." };
        }
        
        public async Task<ResultFeedBack> Detach(TimeSheetModal model)
        {
            var form = _mapper.Map<TimeSheetForm>(model);
            var result_saveChange = _context.Entry(form).State = EntityState.Detached;
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Update Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Update Fail." };
        }
    }
}
