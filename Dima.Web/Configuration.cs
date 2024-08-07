﻿using MudBlazor;

namespace Dima.Web
{
    public static class Configuration
    {
        public const string HttpClientName = "dima";
        public static string BackEndUrl { get; set; } = "https://localhost:7108";

        public static MudTheme Theme = new()
        {
            Typography = new Typography()
            {
                // Caso queira personalizar a fonte para cada tipo , como para um H1, pode fazer isoladamente, ou definir de forma geral usando default
                // H1 = new H1()
                // {
                //     FontFamily........
                // }
                Default = new Default()
                {
                    FontFamily = ["Raleway", "sans-serif"]
                }
            },

            PaletteLight = new PaletteLight
            {
                Primary = new MudBlazor.Utilities.MudColor("#1EFA2D"),
                Secondary = Colors.LightGreen.Darken3,
                // Tertiary = Colors.....  Não usada
                Background = Colors.Gray.Lighten4,
                AppbarBackground = new MudBlazor.Utilities.MudColor("1EFA2D"),
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                PrimaryContrastText = Colors.Shades.Black,
                DrawerText = Colors.Shades.Black, // Cor do menu Lateral
                DrawerBackground = Colors.LightGreen.Lighten4
            },


            PaletteDark = new PaletteDark
            {
                Primary = Colors.LightGreen.Accent3,
                Secondary = Colors.LightGreen.Darken3,
                AppbarBackground = Colors.LightGreen.Accent3,
                AppbarText = Colors.Shades.Black
            }


        };
    }
}
