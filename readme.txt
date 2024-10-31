 Ürün Kategorileri ve Ürün Bilgileri Listeleme Uygulaması README


Proje Hakkında
Bu proje, Visual Studio 2022 platformunda geliştirilen bir .NET web uygulamasıdır ve MongoDB veritabanıyla entegre çalışmaktadır. Uygulama, MongoDB'de saklanan ürün kategorileri ve ürün bilgilerini web tabanlı bir arayüzde listeleyerek kullanıcıların görüntülemesine olanak tanır. Her kategori altında ilgili ürünlerin detayları JSON formatında MongoDB’den çekilerek gösterilmektedir.

Proje Amaçları
MongoDB ile Visual Studio entegrasyonunu sağlamak
Web ortamında ürün kategorilerini ve her kategoriye ait ürün bilgilerini listelemek
MongoDB'den çekilen JSON formatındaki verileri uygulama içerisinde düzenli ve okunabilir bir şekilde kullanıcıya sunmak
Gereksinimler
Aşağıdaki yazılımlar ve kütüphaneler projeye başlamadan önce kurulmuş olmalıdır:

Yazılım Gereksinimleri
Visual Studio 2022 - Projeyi geliştirmek ve yönetmek için
.NET SDK (v6.0 veya üstü) - .NET Web uygulaması geliştirmek için
MongoDB - Veritabanı olarak kullanılmaktadır
MongoDB Compass (isteğe bağlı) - Veritabanı yönetimi için görsel bir araç olarak önerilir
NuGet Paketleri (Kütüphaneler)
Projenin çalışabilmesi için aşağıdaki NuGet paketlerinin yüklenmesi gerekmektedir:

MongoDB.Driver - MongoDB ile bağlantı kurmak ve veri alışverişi yapmak için kullanılır.
shell

Install-Package MongoDB.Driver
Kurulum ve Yapılandırma
Projeyi İndirin veya Klonlayın: Projeyi GitHub veya başka bir kaynak kontrol sisteminden indiriniz ya da klonlayınız.

Gerekli Paketleri Yükleyin: Yukarıda belirtilen NuGet paketlerini yükleyin.

MongoDB Bağlantısını Ayarlayın: appsettings.json dosyasında MongoDB bağlantı ayarlarını yapın:

json

{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "dotnet"
  }
}
Uygulama Yapısı: Projede, ürün kategorilerini listelemek için bir Categories koleksiyonu ve ürün bilgilerini saklamak için Products koleksiyonu kullanılmaktadır. Bu yapı, kategoriler ve ürünlerin düzenli bir şekilde ayrılmasını sağlar.

Uygulamanın Kullanımı
Kategorileri Listeleme: Anasayfa üzerinde, MongoDB’den çekilen ürün kategorileri listelenir. Bu kategoriler, her biri bir kart veya liste elemanı olarak görüntülenir.

Ürün Detaylarını Görüntüleme: Kullanıcı, bir kategori seçtiğinde, o kategoriye ait ürünlerin bilgileri detaylı bir şekilde ekrana getirilir. Ürün bilgileri, MongoDB’den JSON formatında alınarak web arayüzünde düzenlenir ve kullanıcıya sunulur.

Veri Güncelleme ve Yönetimi: MongoDB üzerindeki ürün ve kategori bilgileri güncellendiğinde, bu değişiklikler uygulama arayüzünde otomatik olarak güncellenir.

Kullanıcı Arayüzü
Uygulama, kullanıcı dostu bir arayüz sunar. Arayüzde kategori ve ürün bilgileri düzenli bir liste veya kart yapısında, kolay anlaşılabilir şekilde tasarlanmıştır. Responsive bir tasarım uygulanarak mobil cihazlar için de uygun hale getirilmiştir.

Bilinen Sorunlar ve Çözümler
Veritabanı Bağlantı Sorunları: MongoDB bağlantısı kurulamadığında, bağlantı bilgilerini appsettings.json dosyasından kontrol ediniz ve MongoDB hizmetinin aktif olduğunu doğrulayınız.
JSON Formatı Hataları: JSON verilerinin eksiksiz ve doğru bir formatta MongoDB’ye eklenmiş olduğundan emin olun. JSON veri hatalarında, formatı doğrulamak için araçlar kullanabilirsiniz.