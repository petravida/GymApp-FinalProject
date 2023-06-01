using GYM4URepository.Common;
using GYM4UDAL;
using System;
using System.Linq;
using System.Threading.Tasks;
using GYM4UModel;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;
using System.Diagnostics;
using GYM4U.Common;
using System.Data.SqlClient;
using System.IO;
using GYM4UCommon;
using PagedList;

namespace GYM4URepositpry
{
    public class MemberRepository : /*IDisposable,*/ IMemberRepository
    {
        protected Gym4UEntities Context { get; set; }
        public MemberRepository(Gym4UEntities contex)
        {
            Context = contex;
        }

        //// SECURITY_DBEntities it is your context class
        //Gym4UEntities context = new Gym4UEntities();

        ////This method is used to check and validate the user credentials
        //public Member IsActiveUser()
        //{
        //    return context.Member.FirstOrDefault(user =>
        //  user.IsActive == true);
        //}

        //public void Dispose()
        //{
        //    context.Dispose();
        //}

        public async Task<IPagedList<MemberModelDTO>> GetAllMember(SearchString searchString, Paging paging, Sorting sorting, Filtering filtering)
        {
            int pageNumber = paging.PageNumber;

            IQueryable<Member> query = Context.Member.AsQueryable();
            
            if (!String.IsNullOrEmpty(searchString.SearchQueary))
            {
                string searchQuery = searchString.SearchQueary.ToLower();
                query = query.Where(m => m.FirstName.Contains(searchQuery));
                pageNumber = 1;
            }

            if (filtering != null)
            {
                if (filtering.FirstName != null)
                {
                    query = query.Where(m => m.FirstName.Contains(filtering.FirstName));
                }
                if (filtering.LastName != null)
                {
                    query = query.Where(m => m.LastName.Contains(filtering.LastName));
                }

            }

            int count = query.Count();

            if (paging != null)
            {
                int offset = (pageNumber - 1) * paging.PageSize;
                int fetchNext = paging.PageSize;

                query = query.OrderBy(x => x.Id).Skip(offset).Take(fetchNext);
            }

            if (sorting != null)
            {
                string sortBy = sorting.SortBy;
                string sortOrder = sorting.SortOrder;

                switch (sortBy.ToLower())
                {
                    case "isactive":
                        query = sortOrder.ToLower() == "desc" ? query.OrderByDescending(m => m.IsActive) : query.OrderBy(m => m.IsActive);
                        break;
                    case "lastname":
                        query = sortOrder.ToLower() == "desc" ? query.OrderByDescending(m => m.LastName) : query.OrderBy(m => m.LastName);
                        break;
                    default:
                        query = sortOrder.ToLower() == "desc" ? query.OrderByDescending(b => b.Id) : query.OrderBy(b => b.Id);
                        break;
                }

            }
            
            List<Member> allMembers = await query.ToListAsync();
            IPagedList<MemberModelDTO> memberList = new StaticPagedList<MemberModelDTO>(allMembers.Select<Member, MemberModelDTO>(members => new MemberModelDTO
            {
                Id = members.Id,
                FirstName = members.FirstName,
                LastName = members.LastName,
                Sex = members.Sex,
                DOB = members.DateOfBirth,
                IsActive = members.IsActive
                //OIB = members.OIB,
                //Phone = members.Phone
            }), pageNumber, paging.PageSize, count);

            return memberList;

        }

        public async Task<bool> CreateNewMember(MemberModelDTO member)
        {
            member.Id = Guid.NewGuid();
            member.DateCreated = DateTime.Now;
            member.DateUpdated = DateTime.Now;
            Context.Member.Add(new Member
            {
                Id = Guid.NewGuid(),
                FirstName = member.FirstName,
                LastName = member.LastName,
                Sex = member.Sex,
                DateOfBirth = member.DOB,
                OIB = member.OIB,
                Phone = member.Phone,
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                IsActive = member.IsActive,
                CreatedByUserId = member.CreatedByUserId,
                UpdatedByUserId = member.UpdatedByUserId,
                AppUserId = member.AppUser
               
                

            });

            var numberOfRows = await Context.SaveChangesAsync();

            if (numberOfRows > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<MemberModelDTO> GetMember(Guid id)
        {
            Member member = new Member();
            member = await Context.Member.Where(m => m.Id == id).FirstOrDefaultAsync();
            MemberModelDTO findedMember = new MemberModelDTO();
            if (member != null)
            {
                findedMember.Id = id;
                findedMember.FirstName = member.FirstName;
                findedMember.LastName = member.LastName;
                findedMember.Sex = member.Sex;
                findedMember.DOB = member.DateOfBirth;
                findedMember.OIB = member.OIB;
                findedMember.Phone = member.Phone;
                findedMember.IsActive = member.IsActive;

            }
            return findedMember;
        }

        public async Task<bool> EditMember(Guid id, MemberModelDTO member)
        {
            Member editedMemeber = await Context.Member.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (editedMemeber != null)
            {
                editedMemeber.FirstName = member.FirstName;
                editedMemeber.LastName = member.LastName;
                editedMemeber.Sex = member.Sex;
                editedMemeber.DateOfBirth = member.DOB;
                editedMemeber.OIB = member.OIB;
                editedMemeber.Phone = member.Phone;
                editedMemeber.IsActive = member.IsActive;

                Context.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<bool> DeleteMember(Guid id)
        {
            MemberModelDTO memberForDelete = new MemberModelDTO();
            var member = Context.Member.Where(m => m.Id == id).FirstOrDefault();
            if (id != null)
            {
                Context.Entry(member).State = EntityState.Deleted;
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}