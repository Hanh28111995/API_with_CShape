using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.MissPunchRepository
{
    public class LunchCorrectionFormRepository : ILunchCorrectionFormRepository
    {
        private readonly FormContext _context;
        private readonly IMapper _mapper;

        public LunchCorrectionFormRepository(FormContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LunchCorrectionFormModal> getFormAsync(int ID)
        {
            var form = await _context.LunchCorrectionForms!.FindAsync(ID);
            return _mapper.Map<LunchCorrectionFormModal>(form);
        }

        public async Task<List<LunchCorrectionFormModal>> getAllFormsAsync()
        {
            var forms = await _context.LunchCorrectionForms!.ToListAsync();
            return _mapper.Map<List<LunchCorrectionFormModal>>(forms);
        }

        public async Task<int> AddFormAsync(LunchCorrectionFormModal model)
        {
            var newForm = _mapper.Map<LunchCorrection_Form>(model);
            _context.LunchCorrectionForms!.Add(newForm);
            await _context.SaveChangesAsync();
            return newForm.ID;
        }

        public async Task DeleteFormAsync(int ID)
        {
            var deletedForm = _context.LunchCorrectionForms!.SingleOrDefault(x => x.ID == ID);
            if (deletedForm != null)
            {
                _context.LunchCorrectionForms!.Remove(deletedForm);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ResultFeedBack> UpdateFormAsync(LunchCorrectionFormModal model)
        {
            var updateForm = _mapper.Map<LunchCorrection_Form>(model);
            var result_Update = _context.LunchCorrectionForms!.Update(updateForm);
            var result_saveChange = await _context.SaveChangesAsync();
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Edit Note Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Edit Note Fail." };
        }
    }
}
