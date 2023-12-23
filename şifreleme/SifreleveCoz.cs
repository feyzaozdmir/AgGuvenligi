/*          G201210402
 *        FEYZA NUR ÖZDEMİR
 *      AĞ GÜVENLİĞİ 1-A GRUBU
 */
using System;
using System.Security.Cryptography; //kriptografik işlemleri gerçekleştirmek için eklendi.
using System.Text;

namespace şifreleme
{
    class SifreleveCoz
    {
        private const string AES_IV = @"!&+QWSDF!123126+"; 
        /*Initialization Vector (IV), aynı anahtarı kullanarak şifreleme işlemleri yapılırken,
        aynı veri blokları için farklı şifreli metinlerin üretilmesini sağlamak amacıyla kullanılır.
        Eğer IV kullanılmazsa, aynı veri bloğu her seferinde aynı şifreli metni üretebilir, bu da şifreleme güvenliğini zayıflatabilir.*/
        private string Anahtar = @"ma#>>KOMZ!!%E731";
        /*bir şifreleme anahtarını temsil eder.*/
        public string sifrele(string metin)
        {
            AesCryptoServiceProvider aesSaglayici = new AesCryptoServiceProvider(); //Yeni bir AES şifreleme sağlayıcısı başlattım.(Yeni bir örnek)
            aesSaglayici.BlockSize = 128; 
            aesSaglayici.KeySize = 128;
            //AES algoritması genellikle 128 bit (16 byte) blok boyutu kullanır.Şifreleme algoritmasının güvenlik düzeyini belirler.
            aesSaglayici.IV = Encoding.UTF8.GetBytes(AES_IV); 
            aesSaglayici.Key = Encoding.UTF8.GetBytes(Anahtar);
            //şifreleme işlemleri için gerekli olan Initialization Vector'ı (IV) ve anahtarı atar.
            aesSaglayici.Mode = CipherMode.CBC;
            aesSaglayici.Padding = PaddingMode.PKCS7;

            byte[] kaynak = Encoding.Unicode.GetBytes(metin);
            using (ICryptoTransform sifrele = aesSaglayici.CreateEncryptor())
            {
                byte[] hedef = sifrele.TransformFinalBlock(kaynak, 0, kaynak.Length);
                return Convert.ToBase64String(hedef);
            }
            //şifreleme işlemi için bir şifreleyici oluşturur.Tüm veri bloklarının şifrelenmesini sağlar.
            //Base64, byte dizilerini metin formatında temsil etmek için kullanılan bir kodlama yöntemidir.
        }
        public string sifre_Coz(string sifreliMetin)
        {
            AesCryptoServiceProvider aesSaglayici = new AesCryptoServiceProvider();
            aesSaglayici.BlockSize = 128;
            aesSaglayici.KeySize = 128;
            
            aesSaglayici.IV = Encoding.UTF8.GetBytes(AES_IV);
            aesSaglayici.Key = Encoding.UTF8.GetBytes(Anahtar);
            aesSaglayici.Mode = CipherMode.CBC;
            aesSaglayici.Padding = PaddingMode.PKCS7;
            byte[] kaynak = System.Convert.FromBase64String(sifreliMetin);
            using (ICryptoTransform desifrele = aesSaglayici.CreateDecryptor())
            {
                    byte[] hedef = desifrele.TransformFinalBlock(kaynak, 0, kaynak.Length);
                    return Encoding.Unicode.GetString(hedef);
         
            }
        
        }

    }
}
