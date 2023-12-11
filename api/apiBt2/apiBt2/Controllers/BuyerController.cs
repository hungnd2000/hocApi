using apiBt2.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace apiBt2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        public readonly string _connectionString;
        public BuyerController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("UserCS");
        }

        //get all buyer using oracle command
        [HttpGet("GetAllBuyerUsingOrcCommand")]
        public IActionResult GetAllBuyerUsingOrcCommand()
        {

            List<Buyer> buyerList = new List<Buyer>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "select * from buyer";
                cmd.Connection = connection;
                // Open the connection
                connection.Open();

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Buyer buyer = new Buyer()
                        {
                            Id = Int32.Parse(dr["buyer_id"].ToString()),
                            Name = dr["buyer_name"].ToString(),
                            PaymentMethod = dr["buyer_paymentmethod"].ToString()
                        };
                        buyerList.Add(buyer);
                    }
                }
                else
                {
                    return Ok();
                }
                connection.Close();

            }

            return Ok(buyerList);
        }

        //Get All Buyer Using Produre
        [HttpGet("GetAllBuyerUsingProdure")]
        public IActionResult GetAllBuyerUsingProdure()
        {

            List<Buyer> buyerList = new List<Buyer>();

            string storedProcedureName = "GetAllDataInTable";

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(storedProcedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    OracleParameter cursorParam = new OracleParameter("cursorParam", OracleDbType.RefCursor);
                    cursorParam.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(cursorParam);

                    command.ExecuteNonQuery();

                    OracleDataReader reader = ((OracleRefCursor)cursorParam.Value).GetDataReader();

                    while (reader.Read())
                    {
                        Buyer buyer = new Buyer()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("buyer_id")),
                            Name = reader.GetString(reader.GetOrdinal("buyer_name")),
                            PaymentMethod = reader.GetString(reader.GetOrdinal("buyer_paymentmethod"))
                        };
                        buyerList.Add(buyer);
                    }
                }
            }

            return Ok(buyerList);
        }

        [HttpPost("AddBuyer")]
        public IActionResult AddBuyer(Buyer buyer)
        {
            string storedProcedureName = "add_buyer";

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(storedProcedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("p_buyer_id", OracleDbType.Int32).Value = buyer.Id;
                    command.Parameters.Add("p_buyer_name", OracleDbType.Varchar2).Value = buyer.Name;
                    command.Parameters.Add("buyer_paymentmethod", OracleDbType.Varchar2).Value = buyer.PaymentMethod;
                    command.ExecuteNonQuery();
                }
            }

            return Ok(buyer);
        }

        [HttpPut("UpdateBuyer")]
        public IActionResult UpdateBuyer(Buyer buyer)
        {
            string storedProcedureName = "update_buyer";

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(storedProcedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("p_buyer_id", OracleDbType.Int32).Value = buyer.Id;
                    command.Parameters.Add("p_new_buyer_name", OracleDbType.Varchar2).Value = buyer.Name;
                    command.Parameters.Add("p_new_paymentmethod", OracleDbType.Varchar2).Value = buyer.PaymentMethod;
                    command.ExecuteNonQuery();
                }
            }

            return Ok(buyer);
        }

        [HttpDelete("DeleteBuyer")]
        public IActionResult DeleteBuyer(int buyerId)
        {
            string storedProcedureName = "delete_buyer";

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(storedProcedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("p_buyer_id", OracleDbType.Int32).Value = buyerId;
                    command.ExecuteNonQuery();
                }
            }
            return Ok(buyerId);
        }
    }
}
