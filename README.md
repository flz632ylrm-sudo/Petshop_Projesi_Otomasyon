# 🐾 Petshop Otomasyon Sistemi (C# & MS SQL Server)

Bu proje, bir Petshop işletmesinin ürün (hayvan), müşteri ve sipariş süreçlerini dijital ortamda yönetmek amacıyla
geliştirilmiş, **ilişkisel veritabanı** tabanlı bir masaüstü uygulamasıdır.

Yönetim Bilişim Sistemleri (YBS) perspektifiyle hazırlanan bu otomasyon, verilerin doğruluğunu artırmayı
iş süreçlerini hızlandırmayı ve işletme verimliliğini yükseltmeyi hedeflemektedir.

---

## Öne Çıkan Özellikler

Sistem, veri yönetiminin temel taşı olan **Tam Fonksiyonel CRUD İşlemleri** üzerine inşa edilmiştir:

* **Create (Ekleme):** Yeni ürün (hayvan) ve müşteri kayıtlarının sisteme hatasız şekilde eklenmesi
* **Read (Listeleme):** SQL veritabanındaki verilerin `DataGridView` aracılığıyla anlık görüntülenmesi
* **Update (Güncelleme):** Mevcut kayıtların (satış durumu, fiyat, müşteri bilgileri vb.) güncellenmesi
* **Delete (Silme):** Hatalı veya gereksiz kayıtların güvenli şekilde silinmesi

---

## 🗄 Veritabanı Özellikleri

* **Primary Key yapıları** `IDENTITY` kullanılarak otomatik artan şekilde tasarlanmıştır.
* **Orders (Sipariş) tablosunda** sipariş tarihi `DEFAULT GETDATE()` ile otomatik olarak atanmaktadır.
* Tablolar arasında **Foreign Key (İlişkisel Bağlantılar)** kurulmuştur.
* Veri bütünlüğü için **NOT NULL ve DEFAULT constraint** yapıları kullanılmıştır.
* SQL Server üzerinde **veri tipi dönüşümleri ve tablo güncellemeleri (ALTER TABLE)** uygulanmıştır.

---

## 📸 Uygulama Ekran Görüntüleri

### 1. Ana Giriş Paneli

Kullanıcıyı karşılayan ve sistem modüllerine hızlı erişim sağlayan ana menü.

<img width="1411" height="741" alt="Ekran görüntüsü 2026-04-21 192431" src="https://github.com/user-attachments/assets/b0d90e18-6a1c-435a-8980-f27b5a94a82d" />



### 2. Ürün (Hayvan) Yönetim Modülü

Mağazadaki hayvanların tüm bilgilerinin (ad, tür, yaş, cinsiyet, fiyat) ve satış durumlarının takip edildiği alan.

<img width="1391" height="747" alt="Ekran görüntüsü 2026-04-21 192455" src="https://github.com/user-attachments/assets/33c1a7ee-726d-434b-a20d-655c895d8759" />



### 3. Müşteri ve Satış Modülü

Müşteri bilgilerinin tutulduğu ve yapılan satış işlemlerinin yönetildiği bölüm.

<img width="1325" height="753" alt="Ekran görüntüsü 2026-04-21 192519" src="https://github.com/user-attachments/assets/4e0919c0-d87a-4582-943d-8dbdfaeee043" />




## 🛠 Teknik Mimari ve Yetkinlikler

* **Programlama Dili:** C# (Windows Forms)
* **Veritabanı:** MS SQL Server
* **İlişkisel Veritabanı Tasarımı:** Ürün, müşteri ve sipariş tabloları arasında ilişkiler kurulmuştur
* **T-SQL Kullanımı:**

  * `INNER JOIN` ile ilişkili verilerin birleştirilmesi
  * `ALTER TABLE`, `DEFAULT`, `CONSTRAINT` yapıları
  * Veri bütünlüğü ve otomasyon işlemleri

---

## 📌 Öğrenilenler

Bu proje kapsamında:

* SQL Server’da tablo oluşturma ve yönetme
* Veri tipi dönüşümleri ve hata çözme süreçleri
* DEFAULT ve CONSTRAINT kullanımı
* C# ile veritabanı bağlantısı kurma
* CRUD işlemlerinin gerçek bir senaryoda uygulanması

konularında pratik deneyim kazanılmıştır.


## ⚙️ Kurulum ve Çalıştırma

1. Bu depoyu (repository) klonlayın veya ZIP olarak indirin
2. `Petshop_Projesi_Otomasyon.sln` dosyasını Visual Studio ile açın
3. `App.config` dosyası içerisindeki **Connection String** bilgisini kendi SQL Server ayarlarınıza göre düzenleyin
4. Projeyi derleyin ve çalıştırın

---



