using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyWebApp.DAL.Gateway;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace CompanyWebApp.BLL
{

    public class CompanyManager
    {
        CompanyGateway companyGateway = new CompanyGateway();

        public string Save(Company company)
        {
            if (companyGateway.IsCompanyExists(company.CompanyName))
            {
                return "Company already Exists";
            }
            else
            {
                int rowAffect = companyGateway.Save(company);
                if (rowAffect > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }

        }

        public Company GetCompanyById(int id)
        {
            return companyGateway.GetCompanyById(id);
        }

        public List<Company> GetAllCompany()
        {
            return companyGateway.GetAllCompany();
        }

        private int validationValue = 0;
        public string SetValidation(string tempCompanyName)
        {
            if (String.IsNullOrWhiteSpace(tempCompanyName))
            {
                validationValue = 1;
                return "Company Name is Empty or Only WhiteSpace";
            }

            else if (tempCompanyName.Count(char.IsLetter) < 2)
            {
                validationValue = 1;

                return "Minimum 2 alphabet need for Valid Company name";
            }

            else
            {
                validationValue = 0;
                return "";
            }

        }

        public bool PassValidation()
        {
            if (validationValue == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}