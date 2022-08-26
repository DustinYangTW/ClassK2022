using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MetaDataHomeBackProject.Models
{
    public class MetaAccountDatas
    {
        [Key]
        [DisplayName("使用者帳號")]
        [Required(ErrorMessage = "必填欄位")]
        [EmailAddress(ErrorMessage = "電子郵件格錯誤")]
        [StringLength(64, ErrorMessage = "最長只能輸入64個字")]
        public string EmailAccount { get; set; }
        [DisplayName("使用者密碼")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[A-Za-z0-9]{7,20}", ErrorMessage = "密碼格式錯誤，只能輸入英文跟數字")]
        public string PassWord { get; set; }
    }

    public class MetaADTypeData
    {
        [Key]
        [DisplayName("廣告代號")]
        public short ADID { get; set; }
        [DisplayName("廣告名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string ADName { get; set; }
    }

    public class MetaCarTypeData
    {
        [Key]
        [DisplayName("車位代號")]
        public byte CarTypeID { get; set; }
        [DisplayName("車位名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string CarTypeName { get; set; }
    }

    public class MetaCityTypeData
    {
        [Key]
        [DisplayName("縣市代號")]
        [RegularExpression("[A-Z]{1}", ErrorMessage = "輸入錯誤，請查詢後再輸入")]
        public string CityIDTW { get; set; }
        [DisplayName("縣市名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(5, ErrorMessage = "最長只能輸入5個字")]
        public string CityTW { get; set; }
    }

    public class MetaFactoryadjacentTypeData
    {
        [Key]
        [DisplayName("工廠鄰近物ID")]
        public byte FactoryAdjacentStateID { get; set; }
        [DisplayName("鄰近物名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string FactoryAdjacentName { get; set; }
        [DisplayName("工廠ID")]
        [Required(ErrorMessage = "必填欄位")]
        public string FactoryID { get; set; }
    }

    public class MetaHomeadjacentTypeData
    {
        [Key]
        [DisplayName("房屋鄰近物ID")]
        public byte HomeAdjacentStateID { get; set; }
        [DisplayName("鄰近物名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string HomeAdjacentName { get; set; }
        [DisplayName("房屋ID")]
        [Required(ErrorMessage = "必填欄位")]
        public string HomeID { get; set; }

    }

    public class MetaTerritoryadjacentTypeData
    {
        [Key]
        [DisplayName("工廠鄰近物ID")]
        public byte TerritoryAdjacentStateID { get; set; }
        [DisplayName("鄰近物名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string TerritoryAdjacentName { get; set; }
        [DisplayName("工廠ID")]
        [Required(ErrorMessage = "必填欄位")]
        public string TerritoryID { get; set; }
    }

    public class MetaHomeTypeData
    {
        [Key]
        [DisplayName("房屋類型代碼")]
        public byte HomeTypeID { get; set; }
        [DisplayName("房屋類型")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string HomeTypeName { get; set; }
    }

    public class MetaPeopleRankData
    {
        [Key]
        [DisplayName("會員身分代號")]
        public byte HomeTSaleStateID { get; set; }
        [DisplayName("會員身分")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string PeopleRank { get; set; }
    }

    public class MetaProgramData
    {
        [Key]
        [DisplayName("會員方案代號")]
        public short ProgramSerialID { get; set; }
        [DisplayName("會員方案名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string ProgramName { get; set; }
    }

    public class MetaSaleTypeData
    {
        [Key]
        [DisplayName("銷售狀態代號")]
        public byte SaleStateID { get; set; }
        [DisplayName("銷售狀態")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(5, ErrorMessage = "最長只能輸入5個字")]
        public string SaleState { get; set; }
    }

    public class MetaTerritoryTypeData
    {
        [Key]
        [DisplayName("土地類型代號")]
        public byte TerritorySerialID { get; set; }
        [DisplayName("土地類型")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(10, ErrorMessage = "最長只能輸入10個字")]
        public string TerritoryTypeSelect { get; set; }
    }

    public class MetaPeopleData
    {
        [Key]
        [DisplayName("會員代號")]
        [RegularExpression("[A][0-9]{9}", ErrorMessage = "編號格式錯誤")]
        public string PeopleID { get; set; }
        [DisplayName("姓名")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(55, ErrorMessage = "最長只能輸入55個字")]
        public string PeopleName { get; set; }
        [DisplayName("身份證字號")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[A-Z][1-2][0-9]{8}", ErrorMessage = "身份證字號資料錯誤")]
        [ChechIDName(ErrorMessage = "不合法的身分字號")]
        public string IdebtityNumber { get; set; }
        [DisplayName("生日")]
        [Required(ErrorMessage = "必填欄位")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Birthday { get; set; }
        [DisplayName("性別")]
        [Required(ErrorMessage = "必填欄位")]
        public bool Gender { get; set; }
        [DisplayName("手機號碼")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[0][9][0-9]{8}", ErrorMessage = "電話號碼輸入錯誤")]
        public string PhoneNumber { get; set; }
        [DisplayName("電子信箱")]
        [Required(ErrorMessage = "必填欄位")]
        [EmailAddress(ErrorMessage = "電子郵件格式錯誤")]
        [StringLength(64, ErrorMessage = "最長只能輸入64個字")]
        //[CheckAoccount]
        public string EMail { get; set; }
        [DisplayName("縣市")]
        [Required(ErrorMessage = "必填欄位")]
        public string County { get; set; }
        [DisplayName("鄉鎮")]
        [Required(ErrorMessage = "必填欄位")]
        public string Town { get; set; }
        [DisplayName("道路與號碼")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string RoadAndNumber { get; set; }
        [DisplayName("公司名稱")]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string CompanyName { get; set; }
        [DisplayName("年齡")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> PeopleAge { get; set; }
        [DisplayName("點數")]
        public Nullable<decimal> PeopleCash { get; set; }
        [DisplayName("方案權限時間")]
        public Nullable<System.DateTime> AuthorizationTime { get; set; }
        [DisplayName("會員身分")]
        [Required(ErrorMessage = "必填欄位")]
        public byte SaleStateID { get; set; }
        [DisplayName("方案名稱")]
        public Nullable<short> SchemeName { get; set; }

        public class ChechIDName : ValidationAttribute
        {
            public ChechIDName()
            {
                ErrorMessage = "身份證字號資料錯誤";
            }
            public override bool IsValid(object value)
            {
                int sum = 0;
                string id = value.ToString();
                const string eng = "ABCDEFGHJKLMNPQRSTUVXYZIO";
                string t = id.Substring(0, 1);
                int intEng = eng.IndexOf(t) + 10;
                int n1 = intEng / 10;
                int n2 = intEng % 10;
                int[] a = new int[9];
                for (int i = 0; i < 9; i++)
                {
                    a[i] = Convert.ToInt32(id.Substring(i + 1, 1));
                }
                for (int i = 0; i < 8; i++)
                {
                    sum += a[i] * (8 - i);
                }
                sum += a[8] + n1 + n2 * 9;

                if (sum % 10 == 0)
                    return true;
                return false;
            }
        }

    }

    public class MetaFactoryData
    {
        [Key]
        [DisplayName("廠房編號")]
        [RegularExpression("[F][0-9]{9}", ErrorMessage = "編號格式錯誤")]
        public string FactoryID { get; set; }
        [DisplayName("廠房案名")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string FactoryName { get; set; }
        [DisplayName("售價(萬)")]
        [Required(ErrorMessage = "必填欄位")]
        public decimal FactoryMoney { get; set; }
        [DisplayName("總坪數")]
        [Required(ErrorMessage = "必填欄位")]
        public decimal FactorySquareMeters { get; set; }
        [DisplayName("單坪售價")]
        public Nullable<decimal> FactoryMetersMoney { get; set; }
        [DisplayName("縣市")]
        [Required(ErrorMessage = "必填欄位")]
        public string FactoryCity { get; set; }
        [DisplayName("鄉鎮")]
        [Required(ErrorMessage = "必填欄位")]
        public string FactoryTown { get; set; }
        [DisplayName("街道路")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(10, ErrorMessage = "最長只能輸入10個字")]
        public string FactoryStreet { get; set; }
        [DisplayName("樓層")]
        [RegularExpression("[0-9]{0,4}", ErrorMessage = "格式錯誤")]
        public Nullable<byte> FactoryFloor { get; set; }
        [DisplayName("總樓層")]
        [RegularExpression("[0-9]{0,4}", ErrorMessage = "格式錯誤")]
        public Nullable<byte> FactoryHighFloor { get; set; }
        [DisplayName("屋齡")]
        [Required(ErrorMessage = "必填欄位")]
        public byte FactoryAges { get; set; }
        [DisplayName("售/租")]
        [Required(ErrorMessage = "必填欄位")]
        public bool FactorySaleAndLease { get; set; }
        [DisplayName("廠房特色")]
        [StringLength(1000, ErrorMessage = "最長只能輸入1000個字")]
        public string FactoryFeatures { get; set; }
        [DisplayName("銷售狀態")]
        [Required(ErrorMessage = "必填欄位")]
        public byte FactorySaleType { get; set; }
        [DisplayName("土地類型")]
        [Required(ErrorMessage = "必填欄位")]
        public string FactoryType { get; set; }
        [DisplayName("會員編號")]
        [Required(ErrorMessage = "必填欄位")]
        public string FactoryPeopleID { get; set; }
        [DisplayName("廣告等級")]
        public Nullable<short> FactoryADLevel { get; set; }
    }


    public class MetaHomeData
    {
        [Key]
        [DisplayName("房屋編號")]
        public string HomeID { get; set; }
        [DisplayName("房屋案名")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string HomeName { get; set; }
        [DisplayName("售價(萬)")]
        [Required(ErrorMessage = "必填欄位")]
        public decimal HomeMoney { get; set; }
        [DisplayName("總坪數")]
        [Required(ErrorMessage = "必填欄位")]
        public decimal HomeSquareMeters { get; set; }
        [DisplayName("單坪售價(萬)")]
        public Nullable<decimal> HomeMetersMoney { get; set; }
        [DisplayName("縣市")]
        [Required(ErrorMessage = "必填欄位")]
        public string HomeCity { get; set; }
        [DisplayName("鄉鎮")]
        [Required(ErrorMessage = "必填欄位")]
        public string HomeTown { get; set; }
        [DisplayName("街道路")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(10, ErrorMessage = "最長只能輸入10個字")]
        public string HomeStreet { get; set; }
        [DisplayName("樓層")]
        [RegularExpression("[0-9]{0,4}", ErrorMessage = "格式錯誤")]
        public Nullable<byte> HomeFloor { get; set; }
        [DisplayName("總樓層")]
        [RegularExpression("[0-9]{0,4}", ErrorMessage = "格式錯誤")]
        public Nullable<byte> HomeHighFloor { get; set; }
        [DisplayName("售/租")]
        [Required(ErrorMessage = "必填欄位")]
        public bool HomeSaleAndLease { get; set; }
        [DisplayName("屋齡")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[0-9]{0,4}", ErrorMessage = "格式錯誤")]

        public byte HomeAges { get; set; }
        [DisplayName("房")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[0-9]{0,7}", ErrorMessage = "格式錯誤")]
        public byte HomeRoom { get; set; }
        [DisplayName("廳")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[0-9]{0,7}", ErrorMessage = "格式錯誤")]
        public byte HomeHall { get; set; }
        [DisplayName("衛浴")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[0-9]{0,7}", ErrorMessage = "格式錯誤")]
        public byte HomeBathroom { get; set; }
        [DisplayName("陽台")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "格式錯誤")]
        public byte HomeBalcony { get; set; }
        [DisplayName("房屋特色")]
        [StringLength(1000, ErrorMessage = "最長只能輸入1000個字")]
        public string HomeFeatures { get; set; }
        [DisplayName("管理費")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "格式錯誤")]
        public Nullable<int> HomeManageTip { get; set; }
        [DisplayName("車位類型")]
        [Required(ErrorMessage = "必填欄位")]
        public byte HomeCarID { get; set; }
        [DisplayName("銷售狀態")]
        [Required(ErrorMessage = "必填欄位")]
        public byte HomeSaleType { get; set; }
        [DisplayName("房屋類型")]
        [Required(ErrorMessage = "必填欄位")]
        public byte HomeType { get; set; }
        [DisplayName("會員編號")]
        public string HomePeopleID { get; set; }
        [DisplayName("廣告等級")]
        public Nullable<short> HomeADLevel { get; set; }

    }

    public class MetaTerritoryData
    {
        [Key]
        [DisplayName("土地編號")]
        [RegularExpression("[T][0-9]{9}", ErrorMessage = "編號格式錯誤")]
        public string TerritoryID { get; set; }
        [DisplayName("土地案名")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string TerritoryName { get; set; }
        [DisplayName("售價(萬)")]
        [Required(ErrorMessage = "必填欄位")]
        public decimal TerritoryMoney { get; set; }
        [DisplayName("總坪數")]
        [Required(ErrorMessage = "必填欄位")]
        public decimal TerritorySquareMeters { get; set; }
        [DisplayName("單坪售價")]
        public Nullable<decimal> TerritoryMetersMoney { get; set; }
        [DisplayName("縣市")]
        [Required(ErrorMessage = "必填欄位")]
        public string TerritoryCity { get; set; }
        [DisplayName("鄉鎮")]
        [Required(ErrorMessage = "必填欄位")]
        public string TerritoryTown { get; set; }
        [DisplayName("街道路")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(10, ErrorMessage = "最長只能輸入10個字")]
        public string TerritoryStreet { get; set; }
        [DisplayName("售/租")]
        [Required(ErrorMessage = "必填欄位")]
        public bool TerritorySaleAndLease { get; set; }
        [DisplayName("土地特色")]
        [StringLength(1000, ErrorMessage = "最長只能輸入1000個字")]
        public string TerritoryFeatures { get; set; }
        [DisplayName("銷售狀態")]
        [Required(ErrorMessage = "必填欄位")]
        public byte TerritorySaleType { get; set; }
        [DisplayName("土地類型")]
        [Required(ErrorMessage = "必填欄位")]
        public byte TerritoryType { get; set; }
        [DisplayName("會員編號")]
        [Required(ErrorMessage = "必填欄位")]
        public string TerritoryPeopleID { get; set; }
        [DisplayName("廣告等級")]
        public Nullable<short> TerritoryADLevel { get; set; }
    }



    public class CheckDropDownList : ValidationAttribute
    {
        public CheckDropDownList()
        {
            ErrorMessage = "必填欄位";
        }
        public override bool IsValid(object value)
        {
            string dropDownList = value.ToString();
            if (dropDownList == "false") { return false; }
            
            return true;
        }
    }

}
