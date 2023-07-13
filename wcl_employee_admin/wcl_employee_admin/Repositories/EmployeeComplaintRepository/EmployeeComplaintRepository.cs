using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.EmployeeComplaintRepository
{
    public class EmployeeComplaintRepository : IEmployeeComplaintRepository
    {
        private readonly FormContext _context;
        private readonly IMapper _mapper;

        public EmployeeComplaintRepository(FormContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeComplaintModal>> getGroupFormsAsync(string group)
        {
            var forms = await _context.employeeComplaintForms!.ToListAsync();

            return _mapper.Map<List<EmployeeComplaintModal>>(forms);
        }

        public async Task<EmployeeComplaintModal> getFormAsync(int ID)
        {
            var form = await _context.employeeComplaintForms!.FindAsync(ID);
            return _mapper.Map<EmployeeComplaintModal>(form);
        }

        public async Task<List<EmployeeComplaintModal>> getAllFormsAsync()
        {
            var forms = await _context.employeeComplaintForms!.ToListAsync();
            return _mapper.Map<List<EmployeeComplaintModal>>(forms);
        }

        public async Task<int> AddFormAsync(EmployeeComplaintModal model)
        {
            var newForm = _mapper.Map<EmployeeComplaintForm>(model);
            _context.employeeComplaintForms!.Add(newForm);
            await _context.SaveChangesAsync();
            return newForm.ID;
        }

        public async Task DeleteFormAsync(int ID)
        {
            var deletedForm = _context.employeeComplaintForms!.SingleOrDefault(x => x.ID == ID);
            if (deletedForm != null)
            {
                _context.employeeComplaintForms!.Remove(deletedForm);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ResultFeedBack> UpdateFormAsync(EmployeeComplaintModal model)
        {
            var updateForm = _mapper.Map<EmployeeComplaintForm>(model);
            var result_Update = _context.employeeComplaintForms!.Update(updateForm);
            var result_saveChange = await _context.SaveChangesAsync();
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Edit Note Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Edit Note Fail." };
        }
    }
}
