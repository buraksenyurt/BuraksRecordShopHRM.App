# Blazor Çalışması _(DEVAM EDİYOR)__

Pluralsight'tan aldığım _[Blazor:Getting Started](https://app.pluralsight.com/library/courses/getting-started-blazor/table-of-contents)_ eğitimini çalıştığım Repo.

Örnek uygulama Burağın dünya çapında ün yapmış plak dükkanlarının insan kaynakları yönetimi için kullanılıyor :) Kurstaki CSS giydirme gibi tasarım konularını atladım. Uygulama ortak bir kütüphane dışında data için birde Web API kullanıyor.

## Platform

- Windows 10
- Visual Studio 2019 Community Edition

## Bazı Bilgiler

- Api tarafı veritabanı olarak Local SQL Db kullanıyor _(Pekala farklı bir veritabanı sistemi de seçilebilir)_ Buna erişmek içinse Entity Framework Core'dan yararlanıyor _(Api projesinde kullanılan Nuget paketlerine bakın)_ İlk başta Migration planı oluşturup veritabanını üretmek için, Package Manager Console üstünde Api projesi seçili iken aşağıdaki terminal komutlarını çalıştırmak yeterli. İşlemde bir sorun olmazsa appsettings.json içindeki Connection String bilgisine göre bir veritabanı üretilmiş olmalı.

```bash
Add-Migration InitialCreate
Update-Database
```

İşler yolunda gitti ve hem veritabanı oluştu 

![./assets/screenshot_2.png](./Assets/screenshot_2.png)

hem de API çalışır hale geldi.

![./assets/screenshot_1.png](./Assets/screenshot_1.png)

- App uygulamasında DataService'ler IHttpClientFactory'yi kullanmakta. Bu nedenle program sınıfındaki DI register işleminde yer alan AddHttpClient metodu için Microsoft.Extensions.Http Nuget paketine ihtiyaç var.
- Web API entegrasyonu sonrası çözümü çalıştırırken Multiple Startup Projects kısmında önce Api sonrasında App uygulamalarının ayağa kalkacağını belirtmemiz işimizi kolaylaştırır. Özetle önce Api sonrasında App uygulamaları ayağa kalkmalı.

## Logs (23 Nisan 2021 - Cuma)

Bugün itibariyle eğitimin ilk dört modülünü tamamladım. Şu an itibariyle uygulamada aşağıdaki fonksiyonellikler bulunuyor.

- Çalışanlar listelenebiliyor.
- Bir çalışanın detay bilgisine bakılabiliyor.
- Detay sayfasında çalışanın Longtitude, Latitude değerlerini baz alarak harici Javascript paketi çağırılıp bir harita gösterilebiliyor. _(.Net Razor sayfasından harici Javascript fonksiyonu çağırma)_
- Bir çalışan Modal Dialog yardımıyla Ad, Soyad ve Email gibi sadece zorunlu alanlar içerecek şekilde eklenebiliyor. _(Modal Dialog ile haberleşme)_
- Çalışan ekleme sayfasından daha fazla bilgiye ekleme yapılabiliyor.
- Çalışan verisini silme ve güncelleme fonksiyonları da işliyor.

Çalışma ile ilgili genel sonuçlara ait ekran görüntüleri ise aşağıdaki gibi.

![./assets/screenshot_4.png](./Assets/screenshot_4.png)

![./assets/screenshot_3.png](./Assets/screenshot_3.png)

![./assets/screenshot_5.png](./Assets/screenshot_5.png)

![./assets/screenshot_6.png](./Assets/screenshot_6.png)

![./assets/screenshot_7.png](./Assets/screenshot_7.png)