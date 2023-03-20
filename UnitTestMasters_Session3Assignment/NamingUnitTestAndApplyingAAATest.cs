using UnitTestMasters_Session3Assignment.DataAccess.Entities;

namespace UnitTestMasters_Session3Assignment
{
    public class NamingUnitTestAndApplyingAAATest
    {
        //QUESTION: Create simple unit test using EmployeeFactory



        public class EmployeeFactory
        {
            public virtual Employee CreateEmployee(string firstName,
            string lastName,
            string? company = null,
            bool isExternal = false)
            {
                if (string.IsNullOrEmpty(firstName))
                {
                    throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.",
                        nameof(firstName));
                }

                if (string.IsNullOrEmpty(lastName))
                {
                    throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.",
                        nameof(lastName));
                }

                if (company == null && isExternal)
                {
                    throw new ArgumentException($"'{nameof(company)}' cannot be null or empty when the employee is external.",
                        nameof(company));
                }

                if (isExternal)
                {
                    // we know company won't be null here due to the check above, so 
                    // we can use the null-forgiving operator to notify the compiler of this
                    return new ExternalEmployee(firstName, lastName, company = null!);
                }

                // create a new employee with default values 
                return new InternalEmployee(firstName, lastName, 0, 2500, false, 1);
            }
        }

        [Fact]
        public void Create_An_External_Employee_WHen_FullName_Is_NotNull()
        {
            //Arrange
            EmployeeFactory employeeFactory = new EmployeeFactory();

            //Act
            var sut = employeeFactory.CreateEmployee("Jan Mark", "Bernales", "Company 0", true);

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void Create_An_Internal_Employee_WHen_FullName_Is_NotNull()
        {
            //Arrange
            EmployeeFactory employeeFactory = new EmployeeFactory();

            //Act
            var sut = employeeFactory.CreateEmployee("Jan Mark", "Bernales", null, false);

            //Assert
            Assert.NotNull(sut);
        }

    }
}