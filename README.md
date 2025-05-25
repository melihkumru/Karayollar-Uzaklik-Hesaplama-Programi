# 🚗 Karayolu Mesafe Analiz Sistemi

## 📌 Proje Açıklaması
Bu proje, şehirler arası karayolu mesafelerinin analizini yapan bir C# tabanlı masaüstü uygulamasıdır.  
Kullanıcılar; şehirler arası mesafeleri görüntüleyebilir, en kısa mesafeyi bulabilir ve farklı analiz seçenekleriyle veri üzerinde işlem yapabilirler.

Sistem; şehir, yol ve mesafe bilgilerinin saklandığı ilişkisel bir veritabanı ile entegre çalışır.  
Kullanıcı dostu arayüzü sayesinde kolay kullanım sunar ve veri analizi için çeşitli sorgulara olanak tanır.

## 🛠 Kullanılan Teknolojiler
✔ Geliştirme Dili: C#  

## 📦 Özellikler
✔ Şehirler arası karayolu mesafelerini listeleme  
✔ En kısa mesafe analizleri  
✔ Belirli kriterlere göre şehir filtreleme  
✔ Dinamik olarak yol ekleme / düzenleme  
✔ Veri bütünlüğü sağlayan kısıtlamalar (Foreign Key, CHECK)  
✔ Arayüz üzerinden kolay veri girişi ve sorgulama  

## 🔒 Veri Yapısı
- **Sehir(SehirID, SehirAdı)**
- **Yol(YolID, Sehir1ID, Sehir2ID, MesafeKM)**  
Veritabanı ilişkisel olarak tasarlanmış ve veri tutarlılığı gözetilmiştir.

## 🚀 Kurulum ve Çalıştırma
1. Projeyi Visual Studio ile açın  
2. Veritabanı bağlantısını yapılandırın  
3. Uygulamayı başlatın ve analizleri gerçekleştirin  

## 📌 Notlar
Bu proje, şehirler arası lojistik, ulaşım planlama ve harita tabanlı uygulamalar için temel bir analiz altyapısı sunmaktadır.
