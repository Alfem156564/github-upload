using Common.Helper;
using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Definition;
using Test.Api.Helpers;

namespace Test.Api.Controllers
{
    [Route("api/security")]
    [ApiController]
    public class SecurityTest : ControllerBase
    {
        private readonly IUserTypeManager userTypeManager;

        public SecurityTest(
            IUserTypeManager userTypeManager)
        {
            this.userTypeManager = userTypeManager;
        }

        [HttpPost("encrypt")]
        public IActionResult Encrypt(WordDefinition word)
        {
            try
            {
                string encryptedWord = Security.Encrypt(word.Word);

                return new OkObjectResult(new WordDefinition
                {
                    Word = encryptedWord
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("decrypt")]
        public IActionResult Decrypt(WordDefinition encryptedWord)
        {
            try
            {
                string word = Security.Decrypt(encryptedWord.Word);

                return new OkObjectResult(new WordDefinition
                {
                    Word = word
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("encrypt/aes")]
        public IActionResult AESEncrypt(WordDefinition word)
        {
            try
            {
                string encryptedWord = AES.Encrypt(word.Word);

                return new OkObjectResult(new WordDefinition
                {
                    Word = encryptedWord
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("decrypt/aes")]
        public IActionResult AESDecrypt(WordDefinition encryptedWord)
        {
            try
            {
                string word = AES.Decrypt(encryptedWord.Word);

                return new OkObjectResult(new WordDefinition
                {
                    Word = word
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
