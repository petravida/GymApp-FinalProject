using GYM4URepository.Common;
using GYM4UService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4UModel;
using GYM4U.Common;
using GYM4UCommon;
using PagedList;

namespace GYM4UService
{
    public class MemberService : IMemberService
    {
        protected IMemberRepository Repository { get; set; }

        public MemberService(IMemberRepository repository)
        {
            Repository = repository;
        }
        public async Task<IPagedList<MemberModelDTO>> GetAllMember(SearchString searchString, Paging paging, Sorting sorting, Filtering filtering)
        {
            IPagedList<MemberModelDTO> member = await Repository.GetAllMember(searchString, paging, sorting, filtering);

            return member;
        }

        public async Task<bool> CreateNewMember(MemberModelDTO member)
        {
            bool isAdded = await Repository.CreateNewMember(member);
            return isAdded;

        }
        public async Task<MemberModelDTO> GetMember(Guid id)
        {
            MemberModelDTO memberModel = await Repository.GetMember(id);

            return memberModel;
        }

        public async Task<bool> EditMember(Guid id, MemberModelDTO member)

        {
            MemberModelDTO findMember = await GetMember(id);

            if (findMember == null)
            {

                return false;
            }

            MemberModelDTO memberForUpdate = new MemberModelDTO();
            memberForUpdate.FirstName = member.FirstName == default ? findMember.FirstName : member.FirstName;
            memberForUpdate.LastName = member.LastName == default ? findMember.LastName : member.LastName;
            memberForUpdate.Sex = member.Sex == default ? findMember.Sex : member.Sex;
            memberForUpdate.DOB = member.DOB == default ? findMember.DOB : member.DOB;
            memberForUpdate.OIB = member.OIB == default ? findMember.OIB : member.OIB;
            memberForUpdate.Phone = member.Phone == default ? findMember.Phone : member.Phone;
            memberForUpdate.IsActive = member.IsActive == default ? findMember.IsActive : member.IsActive;


            Task<bool> isEdited = Repository.EditMember(id, memberForUpdate);
            return await isEdited;
        }
    public async Task<bool> DeleteMember(Guid id)
        {
            MemberModelDTO memberCheck = await Repository.GetMember(id);
            if (memberCheck == null)
            {
                return false;
            }
            bool isDeleted = await Repository.DeleteMember(id);
            return isDeleted;
        }
    }
}
