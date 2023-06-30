using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.InjuryReportRepository
{

    public class InjuryReportFormRepository : IInjuryReportFormRepository
    {
        private readonly FormContext _context;
        private readonly IMapper _mapper;

        public InjuryReportFormRepository(FormContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InjuryReportFormModal> getFormAsync(int ID)
        {
            var form = await _context.InjuryReportForms!.FindAsync(ID);
            return _mapper.Map<InjuryReportFormModal>(form);
        }

        public async Task<List<InjuryReportFormModal>> getAllFormsAsync()
        {
            var forms = await _context.InjuryReportForms!.ToListAsync();
            return _mapper.Map<List<InjuryReportFormModal>>(forms);
        }

        public async Task<int> AddFormAsync(InjuryReportFormModal model)
        {
            var newForm = _mapper.Map<InjuryReportForm>(model);
            _context.InjuryReportForms!.Add(newForm);
            await _context.SaveChangesAsync();
            return newForm.ID;
        }

        public async Task DeleteFormAsync(int ID)
        {
            var deletedForm = _context.InjuryReportForms!.SingleOrDefault(x => x.ID == ID);
            if (deletedForm != null)
            {
                _context.InjuryReportForms!.Remove(deletedForm);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ResultFeedBack> UpdateFormAsync(InjuryReportFormModal model)
        {
            var updateForm = _mapper.Map<InjuryReportForm>(model);
            var result_Update = _context.InjuryReportForms!.Update(updateForm);
            var result_saveChange = await _context.SaveChangesAsync();
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Edit Note Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Edit Note Fail." };
        }
    }
}
