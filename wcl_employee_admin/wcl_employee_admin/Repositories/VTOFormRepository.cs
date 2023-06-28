using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories
{
    public class VTOFormRepository : IVTOFormRepository
    {
        private readonly FormContext _context;
        private readonly IMapper _mapper;

        public VTOFormRepository(FormContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VTO_FormModal> getFormAsync(int ID)
        {
            var form = await _context.vtoForms!.FindAsync(ID);
            return _mapper.Map<VTO_FormModal>(form);
        }

        public async Task<List<VTO_FormModal>> getAllFormsAsync()
        {
            var forms = await _context.vtoForms!.ToListAsync();
            return _mapper.Map<List<VTO_FormModal>>(forms);
        }

        public async Task<int> AddFormAsync(VTO_FormModal model)
        {
            var newForm = _mapper.Map<VTO_Form>(model);
            _context.vtoForms!.Add(newForm);
            await _context.SaveChangesAsync();
            return newForm.ID;
        }

        public async Task DeleteFormAsync(int ID)
        {
            var deletedForm = _context.vtoForms!.SingleOrDefault(x => x.ID == ID);
            if (deletedForm != null)
            {
                _context.vtoForms!.Remove(deletedForm);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ResultFeedBack> UpdateFormAsync(VTO_FormModal model)
        {
            var updateForm = _mapper.Map<VTO_Form>(model);
            var result_Update = _context.vtoForms!.Update(updateForm);
            var result_saveChange = await _context.SaveChangesAsync();
            if (result_saveChange != null)
            {
                return new ResultFeedBack() { Action_Result = true, Message = "Edit Note Success." };
            }
            else return new ResultFeedBack() { Action_Result = false, Message = "Edit Note Fail." };
        }
    }
}
