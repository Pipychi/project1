using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_6
{
    // вспомогательный класс для работы с мяукающими объектами (которые издают звуки)
    public static class MeowHelper
    {
        // метод для вызова мяуканья (Meow) для всех объектов, которые издают звук
        public static void MakeMeowForEveryone(List<IMeowing> mewingObjects)
        {
            foreach (var mewingObject in mewingObjects)
            {
                mewingObject.SoundMake(); // вызываем издание звука для каждого объекта
            }
        }
    }
}
