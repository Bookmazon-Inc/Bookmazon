using Bookmazon.Server.Filter;
using Bookmazon.Server.Interfaces;
using Bookmazon.Server.Repos;
using Bookmazon.Shared.Dtos.Book;
using Bookmazon.Shared.Dtos.Supplier;
using Bookmazon.Shared.Dtos.SupplyOrder;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookmazon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private IUnitOfWork _uow;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }


        /// <summary>
        /// get all suppliers 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> Index()
        {

            var suppliers = await _uow.SupplierRepo.GetAllSuppliers();

            return Ok(suppliers.Select(s => s.ToSupplierDto()));
        }
        
        /// <summary>
        /// This Function removes a supplier from the database
        /// </summary>
        /// <param name="supplierDto"></param>
        [HttpPost("RemoveSupplier")]
        public async void RemoveSupplier(SupplierDto supplierDto)
        {
            Supplier s = await _uow.SupplierRepo.GetSupplier(supplierDto.SupplierID);
            _uow.SupplierRepo.RemoveSupplier(s);
            _uow.Commit();
        }
        
        /// <summary>
        /// Get one supplier by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("{ID}")]
        public async Task<ActionResult<SupplierDto>> GetBySupplierID(int ID)
        {
            var supplier = await _uow.SupplierRepo.GetSupplier(ID);

            if(supplier == null)
                return NotFound();


            return supplier.ToSupplierDto();
        }


        /// <summary>
        /// This function adds a new supplier to the database
        /// </summary>
        /// <param name="supplierDto"></param>
        [HttpPost("AddSupplier")]
        public void AddSupplier(SupplierDto supplierDto)
        {
            Supplier s = new Supplier { 
                Title = supplierDto.Title,
                Land = supplierDto.Land,
                PostalCode = supplierDto.PostalCode,
                City = supplierDto.City,
                Street = supplierDto.Street,
                HouseNumber = supplierDto.HouseNumber,
                Email = supplierDto.Email,
                Notes = supplierDto.Notes
            };

            _uow.SupplierRepo.AddSupplier(s);
            _uow.Commit();
        }

        //[HttpPost("AddSupplyOrder")]
        //public void AddSupplyOrder(SupplyOrderCreateDto sopDto)
        //{
        //    SupplyOrder s = new SupplyOrder
        //    {
        //        SupplierID = sopDto.SupplierID,
        //        SupplyOrderDate = sopDto.SupplyOrderDate,
        //        //SupplyOrderPositions = sopDto.SupplyOrderPositions,
        //    };
        //}

        /// <summary>
        /// Connects supplier to book
        /// </summary>
        /// <param name="supplierID"></param>
        /// <param name="ISBN"></param>
        [HttpPost("ConnectSupplierToBook")]
        public void ConnectSupplierToBook(BookSupplierDto bsdto)
        {
            _uow.SupplierRepo.ConnectSupplierToBook(bsdto.SupplierID, bsdto.ISBN);
            _uow.Commit();
        }
    }
}
