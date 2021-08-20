namespace SharedKernel.Tests
{
    public class ExtensionsTests
    {
        //[Theory(DisplayName = "CNPJ Validation, must return Success")]
        //[Trait("SharedKernel", "CNPJ Validation")]
        //[InlineData(57510754000109)]
        //[InlineData(74677109000102)]
        //[InlineData(01848163000191)]
        //[InlineData(40003318000140)]
        //[InlineData(00159552000147)]
        //public void Extensions_ValidateCNPJ_MustReturnSuccess(long cnpj)
        //{
        //    //Arrange & Act
        //    var validCnpj = cnpj.IsCNPJ();

        //    //Assert
        //    Assert.True(validCnpj);
        //}

        //[Theory(DisplayName = "CNPJ Validation, must return Error")]
        //[Trait("SharedKernel", "CNPJ Validation")]
        //[InlineData(111222333444555)]
        //[InlineData(7467000102)]
        //[InlineData(01845555558163000191)]
        //[InlineData(400)]
        //[InlineData(1111111111111111)]
        //public void Extensions_ValidateCNPJ_MustReturnError(long cnpj)
        //{
        //    //Arrange & Act
        //    var invalidCnpj = cnpj.IsCNPJ();

        //    //Assert
        //    Assert.False(invalidCnpj);
        //}

        //[Fact(DisplayName = "Encryption, must return True")]
        //[Trait("SharedKernel", "String encryption")]
        //public void Extensions_Encrypt_MustReturnTrue()
        //{
        //    //Arrange
        //    var plainText = "Jesus humilha satanás";
        //    var encryptedText = "wUQd0D0o1ZW2Py2NcFU235mVWdPiUOgjoenA6un42VaovJ/l+HPl27QFFEXii7xN";

        //    //Act
        //    var encryptResult = Extensions.Encrypt(plainText);

        //    //Assert
        //    Assert.Equal(encryptedText, encryptResult);
        //    Assert.NotEmpty(encryptResult);
        //}

        //[Fact(DisplayName = "Encryption, must return Error")]
        //[Trait("SharedKernel", "String encryption")]
        //public void Extensions_Encrypt_MustReturnError()
        //{
        //    //Arrange
        //    var plainText = "Jesus humilha satanás";
        //    var encryptedText = "wUQd0Ddddaa11dsmsaç0o1ZW2Py2NcFU235mVWdPiUOgjoenA6un42VaovJ/l+HPl27QFFEXii7xN";

        //    //Act
        //    var encryptResult = Extensions.Encrypt(plainText);

        //    //Assert
        //    Assert.NotEqual(encryptedText, encryptResult);
        //}

        //[Fact(DisplayName = "Decrypt, must return Success")]
        //[Trait("SharedKernel", "String decryption")]
        //public void Extensions_Decrypt_MustReturnSuccess()
        //{
        //    //Arrange
        //    var plainText = "Jesus humilha satanás";
        //    var encryptedText = "wUQd0D0o1ZW2Py2NcFU235mVWdPiUOgjoenA6un42VaovJ/l+HPl27QFFEXii7xN";

        //    //Act
        //    var decryptedResult = Extensions.Decrypt(encryptedText);

        //    //Assert
        //    Assert.Equal(plainText, decryptedResult);
        //    Assert.NotEmpty(decryptedResult);
        //}

        //[Fact(DisplayName = "Decrypt, must return Error")]
        //[Trait("SharedKernel", "String decryption")]
        //public void Extensions_Decrypt_MustReturnError()
        //{
        //    //Arrange
        //    var plainText = "Jesus humilha satanás";
        //    var encryptedText = "wUQd0D0o11W2Py2NcFU235mVWdPiUOgjoenA6un42VaovJ/l+HPl27QFFEXii7xN";

        //    //Act
        //    var decryptedResult = Extensions.Decrypt(encryptedText);

        //    //Assert
        //    Assert.NotEqual(plainText, decryptedResult);
        //}
    }
}
