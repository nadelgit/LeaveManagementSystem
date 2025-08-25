using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services;

public class LeaveTypesService(ApplicationDbContext context, IMapper mapper) : ILeaveTypesService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
    {
        var data = await _context.LeaveTypes.ToListAsync();

        //Using AutoMapper
        var viewdata = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
        return (viewdata);
    }

    public async Task<T> Get<T>(int id) where T : class
    {
        var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(m => m.Id == id);

        if (leaveType == null)
        {
            return null;
        }
        var viewdata = _mapper.Map<T>(leaveType);

        return (viewdata);
    }

    public async Task Delete(int? id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(m => m.Id == id);
        if (data != null)
        {
            _context.LeaveTypes.Remove(data);
            await _context.SaveChangesAsync();
        }

    }


    public async Task Edit(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }


    private bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }
    private async Task<bool> CheckIfLeaveTypeNameExists(string name)
    {
        var lowercasename = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(name));
    }

}
