using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Utils
{
    public class Constans
    {
        public const int NOT_AUTHEN_CODE = 401;
        public const int LOGIN_FAILED_CODE = 400;
        public const int INVALID_DATA_CODE = 400;
        public const int USER_EXISTED_CODE = 400;

        public const string NOT_AUTHEN_MSG = "Thông tin xác thực user không đúng";
        public const string LOGIN_FAILED_MSG = "Email hoặc password không đúng";
        public const string INVALID_DATA_MSG = "Dữ liệu không hợp lệ";
        public const string USER_EXISTED_MSG = " Người dùng đã tồn tại";

        public const string BASE_URL = @"C:\Source\Outsite\haima\trade_analytis_api\SAMPLE_API\Export";
        public const string REPORT_1 = "Report/Index";

    }
}