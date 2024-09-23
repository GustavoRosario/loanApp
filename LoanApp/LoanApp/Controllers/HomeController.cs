using LoanApp.Application.Application.Command;
using LoanApp.Domain.Dto;
using LoanApp.Domain.Const;
using LoanApp.Domain.Ports.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoanApp.Application.Helpers;
using LoanApp.Application.Dto;
using LoanApp.Models;
using System.IO;

namespace LoanApp.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationRepository _applicationRepository;
        private ICommandCaller commandCaller;
        private IDoctorTypeRepository doctorTypeRepository;
        private IIdentificationTypeRepository identificationTypeRepository;
        private IProvinceRepository provinceRepository;
        private ISexRepository sexRepository;
        private ITypeFamilyRelationShipRepository typeFamilyRelationShipRepository;
        private ILoanAmount loanAmount;
        private ICommunicationChannelRepository communicationChannelRepository;
        private IYearOfResidenceRepository yearOfResidenceRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IApplicationRepository _applicationRepository, ICommandCaller commandCaller, IDoctorTypeRepository doctorTypeRepository, IIdentificationTypeRepository identificationTypeRepository, IProvinceRepository provinceRepository, ISexRepository sexRepository, ITypeFamilyRelationShipRepository typeFamilyRelationShipRepository, ILoanAmount loanAmount, ICommunicationChannelRepository communicationChannelRepository, IYearOfResidenceRepository yearOfResidenceRepository, IWebHostEnvironment enviroment)
        {
            this._applicationRepository = _applicationRepository;
            this.commandCaller = commandCaller;
            this.doctorTypeRepository = doctorTypeRepository;
            this.identificationTypeRepository = identificationTypeRepository;
            this.provinceRepository = provinceRepository;
            this.sexRepository = sexRepository;
            this.typeFamilyRelationShipRepository = typeFamilyRelationShipRepository;
            this.loanAmount = loanAmount;
            this.communicationChannelRepository = communicationChannelRepository;
            this.yearOfResidenceRepository = yearOfResidenceRepository;
            this._webHostEnvironment = enviroment;
        }

        public IActionResult Index()
        {
            LoadSelectOption();
            return View();
        }

        private void LoadSelectOption()
        {
            ViewBag.selectListProvince = LoadProvince();
            ViewBag.selectListDoctorType = LoadDoctortype();
            ViewBag.selectListIdentificationType = LoadIdentificationType();
            ViewBag.selectListTypeFamilyRelationShip = LoadTypeFamilyRelationShip();
            ViewBag.selectListSex = LoadSex();
            ViewBag.selectListProvinceGeneral = LoadProvince();
            ViewBag.selectListLoanAmount = LoadLoanAmount();
            ViewBag.selectListYearOfResidence = LoadYearOfResidence();
        }

        private List<SelectListItem> LoadProvince()
        {
            var lstProvince = provinceRepository.GetData().Result;

            List<SelectListItem> selectListProvince = lstProvince.ConvertAll(lst =>
            {
                return new SelectListItem()
                {
                    Text = lst.Province.ToUpper(),
                    Value = lst.ProvinceId.ToString(),
                    Selected = false
                };
            });

            return selectListProvince;
        }
        private List<SelectListItem> LoadDoctortype()
        {
            var lstDoctorType = doctorTypeRepository.GetData().Result;

            List<SelectListItem> selectListDoctorType = lstDoctorType.ConvertAll(lst =>
            {
                return new SelectListItem()
                {
                    Text = lst.DoctorType.ToUpper(),
                    Value = lst.DoctorTypeId.ToString(),
                    Selected = false
                };
            });

            return selectListDoctorType;
        }

        private List<SelectListItem> LoadIdentificationType()
        {
            var lstIdentificationType = identificationTypeRepository.GetData().Result;

            List<SelectListItem> selectListIdentificationType = lstIdentificationType.ConvertAll(lst =>
            {
                return new SelectListItem()
                {
                    Text = lst.IdentificationType.ToUpper(),
                    Value = lst.IdentificationType.ToString(),
                    Selected = false
                };
            });

            return selectListIdentificationType;
        }
        private List<SelectListItem> LoadTypeFamilyRelationShip()
        {
            var lstTypeFamilyRelationShip = typeFamilyRelationShipRepository.GetData().Result;

            List<SelectListItem> selectListTypeFamilyRelationShip = lstTypeFamilyRelationShip.ConvertAll(lst =>
            {
                return new SelectListItem()
                {
                    Text = lst.TypeFamilyRelationShip.ToUpper(),
                    Value = lst.TypeFamilyRelationShipId.ToString(),
                    Selected = false
                };
            });

            return selectListTypeFamilyRelationShip;
        }

        private List<SelectListItem> LoadSex()
        {
            var lstSex = sexRepository.GetData().Result;

            List<SelectListItem> selectListSex = lstSex.ConvertAll(lst =>
            {
                return new SelectListItem()
                {
                    Text = lst.Sex.ToUpper(),
                    Value = lst.SexId.ToString(),
                    Selected = false
                };
            });

            return selectListSex;
        }

        private List<SelectListItem> LoadLoanAmount()
        {
            var lstLoanAmount = loanAmount.GetData().Result;

            List<SelectListItem> selectListLoanAmount = lstLoanAmount.ConvertAll(lst =>
            {
                return new SelectListItem()
                {
                    Text = lst.loan_amount,
                    Value = lst.loan_amount.ToString(),
                    Selected = false
                };
            });

            return selectListLoanAmount;
        }

        private List<SelectListItem> LoadYearOfResidence()
        {
            var lstLoanAmount = yearOfResidenceRepository.GetData().Result;

            List<SelectListItem> selectListLoanAmount = lstLoanAmount.ConvertAll(lst =>
            {
                return new SelectListItem()
                {
                    Text = lst.YearOfResidence.ToString(),
                    Value = lst.YearOfResidenceId.ToString(),
                    Selected = false
                };
            });

            return selectListLoanAmount;
        }

        [HttpPost]
        public async Task<IActionResult> SendApplication(UploadModel upload)
        {
            ApplicationDto applicationDto = new ApplicationDto();
            ApplicationEmailDto applicationEmailDto = new ApplicationEmailDto();
            WhatsAppDto whatsaapDto = new WhatsAppDto();
            WhatsApp _whatsaap = new WhatsApp();
            Mail _mail = null;
            int index = 0;

            var fromValue = communicationChannelRepository.GetData(ComunicationChannelType.IssuingTelephone).Result[index].communication_channel_name_value;
            var toValue = communicationChannelRepository.GetData(ComunicationChannelType.ReceiverTelephone).Result[index].communication_channel_name_value;
            var issuingEmail = communicationChannelRepository.GetData(ComunicationChannelType.IssuingEmail).Result[index].communication_channel_name_value;
            var receiverEmail = communicationChannelRepository.GetData(ComunicationChannelType.ReceiverEmail).Result[index].communication_channel_name_value;
            var tokenEmail = communicationChannelRepository.GetData(ComunicationChannelType.TokenEmail).Result[index].communication_channel_name_value;

            whatsaapDto.From = fromValue;
            whatsaapDto.To = toValue;
            _mail = new Mail(issuingEmail, tokenEmail);

            applicationDto.Doctortypeid = int.Parse(Request.Form["lstDcotorType"].ToString());
            applicationDto.Medicalcenter = Request.Form["Hospital"].ToString().ToUpper();
            applicationDto.Provinceid = int.Parse(Request.Form["lstProvince"].ToString());

            if (Request.Form["PassingTime"] != string.Empty)
                applicationDto.Passingtime = Request.Form["PassingTime"].ToString();
            else
                applicationDto.Passingtime = "NA";

            if (Request.Form["Speciality"] != string.Empty)
                applicationDto.Specialty = Request.Form["Speciality"].ToString();
            else
                applicationDto.Specialty = "NA";

            var testVar = Request.Form["lstYearOfResidence"].ToString();


            if (testVar != string.Empty)
                applicationDto.YearofresidenceId = int.Parse(Request.Form["lstYearOfResidence"].ToString());
            else
                applicationDto.YearofresidenceId = 11;//CERO YEAR

            applicationDto.Name = Request.Form["Name"].ToString();
            applicationDto.Lastname = Request.Form["LastName"].ToString();
            applicationDto.Identification = Request.Form["NacionalIdentification"].ToString();
            applicationDto.Sexid = int.Parse(Request.Form["lstSex"].ToString());
            applicationDto.Address = Request.Form["Address"].ToString();
            applicationDto.Personprovinceid = int.Parse(Request.Form["lstSelectProvinceGeneral"].ToString());
            applicationDto.Movil = Request.Form["CelPhone"].ToString();
            applicationDto.Directfamilytelephone = Request.Form["FamilyTelephone"].ToString();
            applicationDto.Directfamilyname = Request.Form["FamilyName"].ToString();
            applicationDto.Typefamilyrelationshipid = int.Parse(Request.Form["lstTypeFamilyRelationShip"].ToString());
            applicationDto.Amounttolend = Request.Form["lstLoanAmount"].ToString();

            var response = commandCaller.ExecuteProcess(applicationDto);

            if (response.Result.Success)
            {
                applicationEmailDto.ApplicationId = _applicationRepository.GetLastId().Result.ToString();
                applicationEmailDto.Doctortype = doctorTypeRepository.GetData(applicationDto.Doctortypeid).Result.DoctorType;
                applicationEmailDto.Medicalcenter = Request.Form["Hospital"].ToString().ToUpper();
                applicationEmailDto.Province = provinceRepository.GetData(applicationDto.Provinceid).Result.Province.ToUpper();
                applicationEmailDto.Passingtime = Request.Form["PassingTime"].ToString().ToUpper();
                applicationEmailDto.Specialty = Request.Form["Speciality"].ToString();
                applicationEmailDto.Yearofresidence = yearOfResidenceRepository.GetData(applicationDto.YearofresidenceId).Result.YearOfResidence;
                applicationEmailDto.Name = Request.Form["Name"].ToString().ToUpper();
                applicationEmailDto.Lastname = Request.Form["LastName"].ToString().ToUpper();
                applicationEmailDto.Identification = Request.Form["NacionalIdentification"].ToString();
                applicationEmailDto.Sex = sexRepository.GetData(applicationDto.Sexid).Result.Sex;
                applicationEmailDto.Address = Request.Form["Address"].ToString().ToUpper();
                applicationEmailDto.Personprovinceid = int.Parse(Request.Form["lstSelectProvinceGeneral"].ToString());
                applicationEmailDto.Movil = Request.Form["CelPhone"].ToString();
                applicationEmailDto.Directfamilytelephone = Request.Form["FamilyTelephone"].ToString();
                applicationEmailDto.Directfamilyname = Request.Form["FamilyName"].ToString();
                applicationEmailDto.Typefamilyrelationship = typeFamilyRelationShipRepository.GetData(applicationDto.Typefamilyrelationshipid).Result.TypeFamilyRelationShip;
                applicationEmailDto.Amounttolend = Request.Form["lstLoanAmount"].ToString();

                var fileName = await UploadFile(upload);

                if (fileName != null && fileName != string.Empty)
                    applicationEmailDto.Identificationimage = fileName;

                _mail.Send(receiverEmail, applicationEmailDto);
            }

            return View();
        }

        //Method to Upload image national identification..GR
        private async Task<string> UploadFile(UploadModel upload)
        {
            var fileName = Path.Combine(_webHostEnvironment.ContentRootPath, "Upload", upload.MyFile.FileName);
            var fileStream = new FileStream(fileName, FileMode.Create);

            await upload.MyFile.CopyToAsync(fileStream);
            fileStream.Close();

            return fileName;
        }
    }
}
