using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IPerson
    {
        List<Person> AddPerson(Person person);
        Person findingOut(int Id);
        Person Updating(Person person);
        List<Person> Deleted(int Id);
        List<Person> presentation();
    }
}
