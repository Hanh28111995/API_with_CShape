using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.Repositories.EmpStartingInfoRepository;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories.EmpStartingInforRepository
{
    public class EmpStartingInforFormRepository : IEmpStartingInfoFormRepository
    {
        private readonly FormContext _context;
        private readonly IMapper _mapper;

        public EmpStartingInforFormRepository(FormContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmpStartingInforModal> getFormAsync(int ID)
        {
            var form = await _context.empStartingInfor!.FindAsync(ID);
            return _mapper.Map<EmpStartingInforModal>(form);
        }

        public async Task<List<EmpStartingInforModal>> getAllFormsAsync()
        {
            var forms = await _context.empStartingInfor!.ToListAsync();
            return _mapper.Map<List<EmpStartingInforModal>>(forms);
        }

        public async Task<int> AddFormAsync(EmpStartingInforModal model)
        {
            var newForm = _mapper.Map<EmpStartingInfoForm>(model);
            _context.empStartingInfor!.Add(newForm);
            await _context.SaveChangesAsync();
            return newForm.ID;
        }

        public async Task DeleteFormAsync(int ID)
        {
            var deletedForm = _context.empStartingInfor!.SingleOrDefault(x => x.ID == ID);
            if (deletedForm != null)
            {
                _context.empStartingInfor!.Remove(deletedForm);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ResultFeedBack> UpdateFormAsync(EmpStartingInforModal model)
        {
            var updateForm = _mapper.Map<EmpStartingInfoForm>(model);
            var result_Update = _context.empStartingInfor!.Update(updateForm);
            var result_saveChange = await _context.SaveChangesAsync();
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Edit Note Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Edit Note Fail." };
        }
    }
}
