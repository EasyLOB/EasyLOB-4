using Newtonsoft.Json;
using System;
/*
{
   "access_token": "ctAPSgixjEldZaa1s62EyVkP2tRlM_JkX7D0G1dEYgPUmRURkxDvL3K1v7UHuchlJ_gzGvBRotqpzUo1Olp3KKjDcE9znP5nRE9dg9KjSd06D_HkHXvvNxxIVLpi8TyiUiOCxIE9sMU1pDNHI880EsC3Zbv0LxShjUsJ5s-BNN-s5hWW1t-utTgvta-5kPUOuGokDS6cfmbfqQJVIsRhM_t4w1MdOLhg7Kgtzr2XO8rFaQ_17ffasrSYidARGRoZUQ5vk57vlOPtguZd7HKdhzwtH9xFuPAysMqKiluZmF16WE6rSOokhWBfbVeQS7e2xEffAPVcX416_Kh2B-fr30979Y5UZaBPr7hN7YSkmuiXZOwLER-74JYB8R2_oJUxo0TYgGf8AlaIglzZsxhj0yhBB7qXBN_9vNx-aXU5bNmBUQ-9Xgdl7SlTrzoohjj5KlyWtgBIBzHzH0PGswnWxtvTI5K96APF0ZzSWpKkFf3oz0lEVw1VnuN8kADmWvxuZGUlEDZIhbJlQozZGnL1Dg",
   "token_type": "bearer",
   "expires_in": 86399,
   "userName": "administrator",
   ".issued": "Mon, 22 Jun 2020 20:32:54 GMT",
   ".expires": "Tue, 23 Jun 2020 20:32:54 GMT"
}
*/
namespace EasyLOB
{
    public class Token
    {
        public string Access_Token { get; set; }

        public string Token_Type { get; set; }

        public int Expires_In { get; set; }

        public string UserName { get; set; }

        [JsonProperty(".issued")]
        public DateTime Issued { get; set; }

        [JsonProperty(".expires")]
        public DateTime Expires { get; set; }
    }
}
