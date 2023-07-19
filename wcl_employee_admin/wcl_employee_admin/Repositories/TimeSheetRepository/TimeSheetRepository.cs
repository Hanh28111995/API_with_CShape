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
            var forms = await _context.timeSheetForm!.ToListAsync();
            return _mapper.Map<List<TimeSheetModal>>(forms);
        }

        public async Task<int> AddFormAsync(TimeSheetModal model)
        {
            var newForm = _mapper.Map<TimeSheetForm>(model);
            _context.timeSheetForm!.Add(newForm);
            await _context.SaveChangesAsync();
            return newForm.ID;
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
            var data = await _context.timeSheetForm.FindAsync(model.ID);
            data = _mapper.Map<TimeSheetForm>(model);
            var result_Update = _context.timeSheetForm!.Update(data);
            var result_saveChange = await _context.SaveChangesAsync();
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Edit Note Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Edit Note Fail." };
        }
    }
}
