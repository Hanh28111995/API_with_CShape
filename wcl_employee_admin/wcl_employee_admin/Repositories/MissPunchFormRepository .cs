using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
using wcl_employee_admin.ViewModel;

namespace wcl_employee_admin.Repositories
{
    public class MissPunchFormRepository : IMissPunchFormRepository
    {
        private readonly FormContext _context;
        private readonly IMapper _mapper;

        public MissPunchFormRepository(FormContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MissPunchFormModal> getFormAsync(int ID)
        {
            var form = await _context.MissPunchForms!.FindAsync(ID);
            return _mapper.Map<MissPunchFormModal>(form);
        }

        public async Task<List<MissPunchFormModal>> getAllFormsAsync()
        {
            var forms = await _context.MissPunchForms!.ToListAsync();
            return _mapper.Map<List<MissPunchFormModal>>(forms);
        }

        public async Task<int> AddFormAsync(MissPunchFormModal model)
        {
            var newForm = _mapper.Map<MissPunchForm>(model);
            _context.MissPunchForms!.Add(newForm);
            await _context.SaveChangesAsync();
            return newForm.ID;
        }

        public async Task DeleteFormAsync(int ID)
        {
            var deletedForm = _context.MissPunchForms!.SingleOrDefault(x => x.ID == ID);
            if (deletedForm != null)
            {
                _context.MissPunchForms!.Remove(deletedForm);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> UpdateFormAsync(MissPunchFormModal model)
        {
            var updateForm = _mapper.Map<MissPunchForm>(model);
             _context.MissPunchForms!.Update(updateForm);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
