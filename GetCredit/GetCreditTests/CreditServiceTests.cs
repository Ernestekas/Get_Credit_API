using GetCredit.Dtos;
using GetCredit.Services;
using GetCredit.Validators;
using Xunit;

namespace GetCreditTests
{
    public class CreditServiceTests
    {
        private readonly CreditValidator _validator;
        private readonly CreditService _creditService;

        public CreditServiceTests()
        {
            _validator = new CreditValidator();
            _creditService = new CreditService(_validator);
        }

        [Fact]
        public void GetOffer_GivenRequestWithTooLowCreditValue_ReturnsNegativeDecisionCreditModel()
        {
            CreditRequestDto request = new CreditRequestDto()
            {
                CreditValue = 1000
            };

            var response = _creditService.GetOffer(request);
            
            Assert.False(response.Decision);
            Assert.Equal(request.CreditValue, response.CredidValue);
            Assert.Equal(0, response.InterestRatePercentage);
        }

        [Fact]
        public void GetOffer_GivenRequestWithTooHighCreditValue_ReturnNegativeDecisionCreditModel()
        {
            CreditRequestDto request = new CreditRequestDto()
            {
                CreditValue = 70000
            };

            var response = _creditService.GetOffer(request);

            Assert.False(response.Decision);
            Assert.Equal(request.CreditValue, response.CredidValue);
            Assert.Equal(0, response.InterestRatePercentage);
        }

        [Fact]
        public void GetOffer_GivenValidCredit_ReturnPossitiveDecision3Perc()
        {
            CreditRequestDto request = new CreditRequestDto()
            {
                CreditValue = 19000
            };

            var response = _creditService.GetOffer(request);

            Assert.True(response.Decision);
            Assert.Equal(3, response.InterestRatePercentage);
            Assert.Equal(request.CreditValue, response.CredidValue);
        }

        [Fact]
        public void GetOffer_GivenValidCredit_ReturnPossitiveDecision4Perc()
        {
            CreditRequestDto request = new CreditRequestDto()
            {
                CreditValue = 30000
            };

            var response = _creditService.GetOffer(request);

            Assert.True(response.Decision);
            Assert.Equal(4, response.InterestRatePercentage);
            Assert.Equal(request.CreditValue, response.CredidValue);
        }

        [Fact]
        public void GetOffer_GivenValidCredit_ReturnPossitiveDecision5Perc()
        {
            CreditRequestDto request = new CreditRequestDto()
            {
                CreditValue = 50000
            };

            var response = _creditService.GetOffer(request);

            Assert.True(response.Decision);
            Assert.Equal(5, response.InterestRatePercentage);
            Assert.Equal(request.CreditValue, response.CredidValue);
        }

        [Fact]
        public void GetOffer_GivenValidCredit_ReturnPossitiveDecision6Perc()
        {
            CreditRequestDto request = new CreditRequestDto()
            {
                CreditValue = 61000
            };

            var response = _creditService.GetOffer(request);

            Assert.True(response.Decision);
            Assert.Equal(6, response.InterestRatePercentage);
            Assert.Equal(request.CreditValue, response.CredidValue);
        }
    }
}
