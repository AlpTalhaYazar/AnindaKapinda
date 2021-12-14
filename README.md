# AnindaKapinda

## Procedural Design



<div style="padding:16px;background-color:#343434;">
<h2>AnındaKapında Projesi</h2>
<br>
<p>Bu doküman geliştirilecek AnındaKapında adlı ugulamanın analizini içermektedir. Projenin amacı kullanıcıların istedikleri saatte uygulama üzerinde bulunan ürünleri, en hızlı şekilde istedikleri adrese sipariş verebilmesidir.</p>
<p>Uygulama ile öncesinde belirlenen il ve bölgelere hizmet verilecektir. Uygulama iş kurallarına bağlı olarak her üye olan müşterinin sipariş verdiği ürünleri gönderecektir. Üyeler yalnızca kredi kartı ile ödeme yapabileceklerdir. Ürünlerin tedarik edilmesi kapsam dışıdır.</p>
<ul>
    <li>Kullanıcılar üyelik formunu doldurup, epostalarını onayladıktan sonra sisteme üye olacaktır.</li>
    <li>Üyeler siteye giriş yaptığında anasayfa ekranı gözükecektir.</li>
    <li>Anasayfa ekranında ürün kategorileri gözükecek, üyeler istedikleri kategoriye tıklayarak ürünleri ve fiyatlarını görüntüleyebilecek.</li>
    <li>Üyeler istedikleri ürünleri sepetlerine ekleyebilecek, ürün ekledikçe ana ekrandaki sepet simgesinde tutar artacak.</li>
    <li>Sepete gittiklerinde seçtikleri ürünleri, fiyatları, miktarları ve toplam tutarı görebilecekler.</li>
    <li>Sepette ürün miktarını arttırma veya azaltma seçenekleri bulunacak, buna bağlı olarak sepet tutarı değişecektir.</li>
    <li>Üyeler sepeti onayladıklarında karşılarına ödeme ekranı çıkacak. Bu ekranda daha önce tanımlıysa varolan kart bilgileri, tanımlamadıysa kart bilgisi ekleme butonu gözükecek.</li>
    <li>Üyeler hesabım sekmesine tıkladığında üye profillerini, geçmiş siparişlerini, adres ve kart bilgilerini görebilecek ve isterse düzenleyebilecek.</li>
    <li>Üyelerin verdikleri siparişler tedarik noktası görevlisinin sistemine düşecek, görevli buradan siparişi görüp hazırlayacak ve hazır olduğunda kargocuları yönlendirecek.</li>
    <li>Kargocu sistem üzerinden kendisine yönlendirilen siparişleri görebilecek.
    <li>Kargocu ürünü teslim ettiğinde bunu sisteme girecek.</li>
    <li>Sistem sipariş ve teslim zamanı bilgisi tutacaktır.</li>
    <li>Sistemde yöneticiler ve üyeler sadece kendilerine ait sayfaları görebileceklerdir.</li>
</ul>
<br>
<h2>Kullanıcı Tipleri</h2>

<table style="border: 2px solid gray;border-collapse: collapse;">
    <tr class="row">
        <th class="col">Kullanıcı</th>
        <th class="col">Açıklama</th>
    </tr>
    <tr class="row">
        <td class="col"><b>Üye</b></td>
        <td class="col">Uygulama üzerinden ürünleri görebilen,sipariş verebilen kullanıcıdır.</td>
    </tr>
    <tr class="row">
        <td class="col"><b>Tedarik Noktası Görevlisi</b></td>
        <td class="col">Uygulama üzerinden verilen sipaşleri görüntüleyip hazırlayan,hazırladığını bildiren,kuryeleri yönlendiren kişidir.</td>
    </tr>
    <tr class="row">
        <td class="col"><b>Kargocu</b></td>
        <td class="col">Siparişleri tedarik noktasından alıp müşteriye götüren kişilerdir.</td>
    </tr>
    <tr class="row">
        <td class="col"><b>Admin</b></td>
        <td class="col">Sistem yöneticisidir.</td>
    </tr>
</table>
<br>
<h2>Kullanım Senaryoları</h2>

<h3>Üye Olma</h3>
<p>Site açıldığında yer alan Üye Ol linki üzerinden açılan sayfada ad, soyad, mail adresi, şifre ve şifre tekrar alanları bulunur. Bu alanların hepsi zorunludur. Şifre en az 8 karakter olmalı ve büyük harf, küçük harf ve rakam içermelidir. Kullanıcı bilgileri girdikten sonra üyeliği tamamla diyerek kaydını gerçekleştirir.</p>

<h3>Üye Girişi</h3>
<p>Site açıldığında yer alan giriş ekranı üzerinden sisteme giriş yapılır. Üye, Tedarik Noktası Görevlisi, Kargocu ve Admin tipindeki kullanıcılar sistemde kayıtlı mail ve şifre bilgilerini girdikten sonra Giriş Yap butonuna tıklarlar.
Üyeler kayıt esnasında verdikleri mail ve şifre bilgileriyle giriş sağlarlar. Tedarik Noktası Görevlisi ve Kargocu tipindeki kullanıcılar mail adresleri ve Admin kullanıcısı tarafından kendilerine atanan şifre ile giriş sağlarlar. İlk girişlerinde sistem şifre değişikliği ekranına yönlendirerek, en az 8 karakterden oluşan ve büyük harf, küçük harf ve rakam içeren yeni bir şifre belirlemelerini ister. Admin kullanıcısı ise sistem ayağa kaldırılırken oluşturulan mail ve şifre bilgileriyle sisteme giriş sağlar. Her mail adresine sadece bir kullanıcı hesabı tanımlıdır.</p>

<h3>Ürün İşlemleri</h3>
<p>Admin kullanıcısı kendisine sunulan menü üzerinden sistemde tanımlı ürün ve kategorilerle ilgili işlemleri yürütür. Kategori ekleme, güncelleme ve kaldırma işlemlerini gerçekleştirir. Ürün ekleme, güncelleme ve kaldırma işlemlerini yapar.</p>
<p>Kategorilerin sadece adı vardır ve bir ad sadece bir kategoriyi tanımlar.</p>
<p>Ürünlerin adı, fiyatı, indirimli fiyatı, açıklaması ve görseli vardır. Her ürünün bir kategorisi vardır. Sistemde aynı isimde tek bir ürün olur. İndirimli fiyat alanı boş bırakılırsa o ürün için indirim yapılamayacağı anlamına gelir. Görseli olmayan ürünler için Üye tipindeki kullanıcılara “Görsel Hazırlanıyor” şeklinde standart bir görsel sunulur.</p>
<p>Kategori ve ürün kaldırma işlemlerinde “Emin misiniz?” şeklinde bir uyarı ekranı açılır. Bu ekranda onay verilirse işlem tamamlanır. Kaldırılan kategori ve ürünlerin bilgisi eski siparişlerden kaldırılmaz.</p>
<br>
<h3>Sipariş Verme</h3>
<p>Sisteme giriş yapan Üye tipindeki kullanıcıların kayıtlı en az bir adresleri varsa anasayfada kategorileri ve ürünleri görürler. İstedikleri ürünleri sepetlerine ekleyebilirler. Eğer sistemde kayıtlı bir adres yoksa öncelikle adres eklemeleri için gerekli ekran açılır.</p>
<p>Adres ekleme ekranında şehir listesi sunulur. Buradan yapılan seçime göre ilgili şehrin ilçe listesi sunulur. İlçe seçiminden sonra detaylı adres bilgisi alanına mahalle, sokak ve adres tarifi gibi bilgiler girilerek adres ekleme işlemi tamamlanır.</p>
<p>Üye tipindeki kullanıcılar sisteme istedikleri kadar adres bilgisi ekleyebilirler. Birden fazla adres bilgisine sahip kullanıcılar giriş yaptıklarında önce sipariş verecekleri adresi seçerler.</p>
<p>Üyeler sepetlerine tıkladıklarında ekledikleri ürünleri görebilirler. Sepet boş değilse siparişi onayla diyerek sipariş verme işlemini tamamlarlar. Üyeler verdikleri siparişlerin durumunu görebilirler. Sipariş başarılı bir şekilde oluştuğunda durumu “Hazırlanıyor” olur. Sipariş hazırlanıp kargocu atandığında “Yola Çıktı” şeklinde değişir. Ayrıca üye siparişi getiren kargocunun bilgilerini görüntüleyebilir.</p>
<br>
<h3>Siparişin Hazırlanması ve Teslimi</h3>
<p>Üye tarafından başarılı bir şekilde oluşturulmuş siparişler Tedarik Merkezi Görevlisi tipindeki kullanıcının sistemine düşer. Bu kullanıcı sisteme giriş yaptığında hazırlanması için bekleyen siparişleri görüntüler. Siparişi hazırladıktan sonra “Hazırlandı” butonuna basıp kargocu listesinden seçim yaparak teslimat için ilgili kargocuya yönlendirme yapar.</p>
<p>Tedarik Merkezi Görevlisi tipindeki kullanıcı hazırladığı siparişi kargocuya yönlendirdiğinde Kargocu tipindeki kullanıcının sistemine düşer. Kargocu kullanıcısı giriş yaptığında kendisine yönlendirilen siparişleri görüntüler. Kargocu ilgili adrese giderek siparişi teslim eder. Ardından kendi ekranından siparişi “Teslim Edildi” diye işaretler. Teslimat yapamadığında “Adres Eksik/Hatalı” veya “Üye Adreste Yoktu” durumlarından ilgili olanı seçerek sipariş durumunu değiştirir. Siparişi veren Üye de bu sipariş durumlarını kendi ekranında görüntüler.</p>
<br>
<h3>Çalışan Kaydı</h3>
<p>Sistemde Tedarik Merkezi Görevlisi ve Kargocu tipinde çalışanlar bulunur. Bu çalışanları sisteme Admin kullanıcısı kendisine sunulan menülerden seçim yaparak ekler. Admin tüm çalışanları görebildiği gibi işten ayrılanları da sistemden kaldırabilir.</p>
<p>Çalışanları eklerken ad, soyad, doğum tarihi, telefon numarası, mail ve şifre alanlarına ilgili bilgileri girerek “Ekle” butonuna tıklar. Ekleme işlemi başarılı olduğunda çalışanın mail adresine giriş bilgilerini içeren bir mail gönderilir.</p>
</div>