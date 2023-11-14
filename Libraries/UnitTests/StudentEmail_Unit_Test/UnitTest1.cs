namespace StudentEmail_Unit_Test;

public class UnitTest1
{

    [Fact]
    public void TestInvalidLength()
    {
        Assert.Equal(10, UI.StudentEmailValidation("a19300107@ceti", 12345678));
    }

    [Fact]
    public void TestInvalidFirstCharacter()
    {
        Assert.Equal(20, UI.StudentEmailValidation("b19300107@ceti.mx", 12345678));
    }

    [Fact]
    public void TestInvalidDomain()
    {
        Assert.Equal(10, UI.StudentEmailValidation("a19300107@ceti.com", 12345678));
    }

    [Fact]
    public void TestInvalidCharacterAfterRegistration()
    {
        Assert.Equal(10, UI.StudentEmailValidation("a19300107z@ceti.mx", 12345678));
    }

    [Fact]
    public void TestInvalidRegistrationFormat()
    {
        Assert.Equal(30, UI.StudentEmailValidation("a1x300107@ceti.mx", 12345678));
    }

    [Fact]
    public void TestAdditionalCharactersAfterDomain()
    {
        Assert.Equal(10, UI.StudentEmailValidation("a19300107@ceti.mxextra", 12345678));
    }

    [Fact]
    public void TestSpecialCharactersInEmail()
    {
        Assert.Equal(30, UI.StudentEmailValidation("a1930!007@ceti.mx", 12345678));
    }

    [Fact]
    public void TestUppercaseDomain()
    {
        Assert.Equal(30, UI.StudentEmailValidation("a19300107@CETI.MX", 12345678));
    }

    [Fact]
    public void TestValidEmail()
    {
        Assert.Equal(1, UI.StudentEmailValidation("a20300692@ceti.mx", 20300692));
    }

}