namespace ExaminationRooms.Web.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    //interfejs "hadlera" komend, użyty został tu typ generyczny <T> który musi być typem implementującym interfejs ICommand
    //oznacza to, że jesli klasa będzie implementowala interfejs ICommandHandler<NazwaTypu> to będzie ona musiała implementować metodę Handle(NazwaTypu)
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
