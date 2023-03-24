using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assemble
{
    public interface IChildCommds
    {
        void DoInquire(); // 조회 버튼 기능
        void DoNew();     // 추가 버튼
        void DoDelete();  // 삭제 버튼
        void DoSave();    // 저장 버튼
    }
}
