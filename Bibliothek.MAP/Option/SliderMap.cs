using Bibliothek.Core.Map;
using Bibliothek.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.MAP.Option
{
    public class SliderMap:CoreMap<Slider>
    {
        public SliderMap()
        {
            ToTable("dbo.Sliders");
            Property(x => x.SliderPath).IsOptional();
            Property(x => x.Queue).IsOptional();
        }
    }
}
