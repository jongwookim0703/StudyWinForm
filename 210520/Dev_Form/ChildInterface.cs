using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Form
{
    public interface ChildInterface
    {   // 부모폼을 자식폼에 있는 함수에 연결
        // 인터페이스가 된 폼에서는 항상 인터페이스가 될 대상을 받아줘야함
        void Inquire();
        void DoNew();
        void Delete();
        void Save();
    }
}
