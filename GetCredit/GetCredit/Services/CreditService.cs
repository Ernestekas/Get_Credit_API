using GetCredit.Dtos;
using GetCredit.Validators;

namespace GetCredit.Services
{
    public class CreditService
    {
        private readonly CreditValidator _validator;

        public CreditService(CreditValidator validator)
        {
            _validator = validator;
        }

        public CreditDetailsDto GetOffer(CreditRequestDto requestData)
        {
            var validationResult = _validator.Validate(requestData);
            if (validationResult.IsValid)
            {
                return FormOffer(requestData);
            }

            return new CreditDetailsDto()
            {
                Decision = false,
                CredidValue = requestData.CreditValue,
                InterestRatePercentage = 0
            };
        }

        private CreditDetailsDto FormOffer(CreditRequestDto request)
        {
            CreditDetailsDto offer = new CreditDetailsDto()
            {
                Decision = true,
                CredidValue = request.CreditValue
            };

            if(request.CreditValue < 20000)
            {
                offer.InterestRatePercentage = 3;
            }
            if(request.CreditValue >= 20000 && request.CreditValue <= 39999)
            {
                offer.InterestRatePercentage = 4;
            }
            if(request.CreditValue >= 40000 && request.CreditValue <= 59999)
            {
                offer.InterestRatePercentage = 5;
            }
            if(request.CreditValue > 60000)
            {
                offer.InterestRatePercentage = 6;
            }
            return offer;
        }
    }
}
