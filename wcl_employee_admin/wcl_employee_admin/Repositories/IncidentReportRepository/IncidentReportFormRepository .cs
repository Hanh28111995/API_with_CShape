using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.IncidentReportRepository
{
    public class IncidentReportFormRepository : IIncidentReportFormRepository
    {
        private readonly FormContext _context;
        private readonly IMapper _mapper;

        public IncidentReportFormRepository(FormContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IncidentReportFormModal> getFormAsync(int ID)
        {
            var form = await _context.IncidentReportForms!.FindAsync(ID);
            return _mapper.Map<IncidentReportFormModal>(form);
        }

        public async Task<List<IncidentReportFormModal>> getGroupFormsAsync(string group)
        {
            var forms = await _context.IncidentReportForms!.ToListAsync();

            return _mapper.Map<List<IncidentReportFormModal>>(forms);
        }

        public async Task<List<IncidentReportFormModal>> getAllFormsAsync()
        {
            var forms = await _context.IncidentReportForms!.ToListAsync();
            return _mapper.Map<List<IncidentReportFormModal>>(forms);
        }

        public async Task<int> AddFormAsync(IncidentReportFormModal model)
        {
            var newForm = _mapper.Map<IncidentReportForm>(model);
            _context.IncidentReportForms!.Add(newForm);
            await _context.SaveChangesAsync();
            return newForm.ID;
        }

        public async Task DeleteFormAsync(int ID)
        {
            var deletedForm = _context.IncidentReportForms!.SingleOrDefault(x => x.ID == ID);
            if (deletedForm != null)
            {
                _context.IncidentReportForms!.Remove(deletedForm);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ResultFeedBack> UpdateFormAsync(IncidentReportFormModal model)
        {
            var updateForm = _mapper.Map<IncidentReportForm>(model);
            var result_Update = _context.IncidentReportForms!.Update(updateForm);
            var result_saveChange = await _context.SaveChangesAsync();
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Edit Note Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Edit Note Fail." };
        }
    }
}
