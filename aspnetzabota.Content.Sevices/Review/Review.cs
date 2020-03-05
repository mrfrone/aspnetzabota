using AutoMapper;
using aspnetzabota.Content.Database.Repository.Review;
using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Review;
using System.Threading.Tasks;
using X.PagedList;
using System;
using aspnetzabota.Common.Result;

namespace aspnetzabota.Content.Services.Review
{
    internal class Review : IReview
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public Review(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }
        public async Task<IEnumerable<ZabotaReview>> RandomReviews(int Count)
        {
            var result = await _reviewRepository.Random(Count);
            return _mapper.Map<IEnumerable<ZabotaReview>>(result);
        }
        public async Task<IEnumerable<ZabotaReview>> GetPagedReviewsList(int pageNumber, int pageSize, bool Moderated = false)
        {
            var result = await _reviewRepository.GetList(false, Moderated);
            return _mapper.Map<IEnumerable<ZabotaReview>>(result).ToPagedList(pageNumber, pageSize);
        }
        public async Task<ZabotaResult> Add(ZabotaReview review)
        {
            review.Date = DateTimeOffset.UtcNow;
            await _reviewRepository.Add(review);

            return new ZabotaResult();
        }
        public async Task<ZabotaResult> ModerateReview(int id)
        {
            await _reviewRepository.Moderate(id);

            return new ZabotaResult();
        }
        public async Task<ZabotaResult> DeleteReview(int id)
        {
            await _reviewRepository.Delete(id);

            return new ZabotaResult();
        }
    }
}
