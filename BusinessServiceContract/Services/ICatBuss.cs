using DomainModel.DTO.Category;

namespace BusinessServiceContract.Services
{
    public interface ICatBuss
    {
        CategoryComplexResult GetParent(int id);
        CategoryComplexResult GetChildren(int id);
        CategoryComplexResult GetParentList(int id);
        bool HasProduct(int id);
        bool HasChild(int id);
        bool DuplicateName(string CategoryName);
        bool DuplicateName(string CategoryName, int id);
    }
}
