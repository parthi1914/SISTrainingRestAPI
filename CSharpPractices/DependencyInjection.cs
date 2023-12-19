using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{

    class LooslyCoupled
    {

        //static void Main(string[] args)

        //{
        //    PrivateCompany objPrivateCompany = new PrivateCompany();

        //    PublicCompany objPublicCompany = new PublicCompany();

        //    VendorCompany objVendorCompany = new VendorCompany();


        //    //PrivateCompany class  object
        //    constructorinjection constructorinjectionPrivate = new constructorinjection(objPrivateCompany);

        //    constructorinjectionPrivate.GetEmployee();
        //    //PublicCompany  class object
        //    constructorinjection constructorinjectionPublic = new constructorinjection(objPublicCompany);

        //    constructorinjectionPublic.GetEmployee();


        //    constructorinjection constructorinjectionVendor = new constructorinjection(objVendorCompany);
        //    constructorinjectionVendor.GetEmployee();
        //}
    }

    public class constructorinjection
    {
        private ICompanyTest _iCompanyTest;
        public constructorinjection(ICompanyTest iCompanyTest)
        {
            this._iCompanyTest = iCompanyTest;
        }
        public void GetEmployee()
        {
            _iCompanyTest.GetEmployee();
        }
    }

    //  ICompanyTest iCompanyTest = object of implemented class 
    //ICompanyTest iCompanyTest = new PrivateCompany();
    //ICompanyTest iCompanyTest = new PublicCompany();

    public interface ICompanyTest
    {
        void GetEmployee();
        void SaveEmployee();

        void UpdateEmployee();
    }



    public class PrivateCompany : ICompanyTest
    {
        public void UpdateEmployee()
        {
            Console.WriteLine("I am from PrivateCompany-UpdateEmployee");
        }

        void ICompanyTest.GetEmployee()
        {
            Console.WriteLine("I am from PrivateCompany-GetEmployee");
        }

        void ICompanyTest.SaveEmployee()
        {
            Console.WriteLine("I am from PrivateCompany-SaveEmployee");
        }
    }



    public class PublicCompany : ICompanyTest
    {
        public void UpdateEmployee()
        {
            Console.WriteLine("I am from PublicCompany-UpdateEmployee");
        }

        void ICompanyTest.GetEmployee()
        {
            Console.WriteLine("I am from PublicCompany-GetEmployee");
        }

        void ICompanyTest.SaveEmployee()
        {
            Console.WriteLine("I am from PublicCompany-SaveEmployee");
        }
    }

    public class VendorCompany : ICompanyTest
    {
        public void GetEmployee()
        {
            throw new NotImplementedException();
        }

        public void SaveEmployee()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
