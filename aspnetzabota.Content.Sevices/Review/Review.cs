using AutoMapper;
using aspnetzabota.Content.Database.Repository.Review;
using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Review;
using System.Threading.Tasks;
using X.PagedList;
using System;

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
        public async Task<IEnumerable<ZabotaReview>> GetPagedReviewsList(int pageNumber, int pageSize)
        {
            var result = await _reviewRepository.GetList();
            return _mapper.Map<IEnumerable<ZabotaReview>>(result).ToPagedList(pageNumber, pageSize);
        }
        public async Task Add(ZabotaReview review)
        {
            review.Date = DateTime.UtcNow;
            await _reviewRepository.Add(review);
        }
    }
}
