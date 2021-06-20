namespace AnimalHealthApp.Services.Utilities
{
    public static class Messages
    {
        // Messages.VeterinaryClinic.NotFound()
        public static class VeterinaryClinic
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir veteriner kliniği bulunamadı.";
                return "Böyle bir kategori bulunamadı.";
            }

            public static string Add(string veterinaryClinicName)
            {
                return $"{veterinaryClinicName} adlı veteriner kliniği başarıyla eklenmiştir.";
            }

            public static string Update(string veterinaryClinicName)
            {
                return $"{veterinaryClinicName} adlı veteriner kliniği başarıyla güncellenmiştir.";
            }
            public static string Delete(string veterinaryClinicName)
            {
                return $"{veterinaryClinicName} adlı veteriner kliniği başarıyla silinmiştir.";
            }
            public static string HardDelete(string veterinaryClinicName)
            {
                return $"{veterinaryClinicName} adlı veteriner kliniği başarıyla veritabanından silinmiştir.";
            }
        }

        public static class Animal
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hayvanlar bulunamadı.";
                return "Böyle bir hayvan bulunamadı.";
            }
            public static string Add(string animalName)
            {
                return $"{animalName} başlıklı hayvan başarıyla eklenmiştir.";
            }

            public static string Update(string animalName)
            {
                return $"{animalName} başlıklı hayvan başarıyla güncellenmiştir.";
            }
            public static string Delete(string animalName)
            {
                return $"{animalName} başlıklı hayvan başarıyla silinmiştir.";
            }
            public static string HardDelete(string animalName)
            {
                return $"{animalName} başlıklı hayvan başarıyla veritabanından silinmiştir.";
            }
        }
    }
}
