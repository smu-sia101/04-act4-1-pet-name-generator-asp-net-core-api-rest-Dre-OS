using Microsoft.AspNetCore.Mvc;
using _04_act4_1_pet_name_generator_asp_net_core_api_rest_Dre_OS.Constants;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;

namespace _04_act4_1_pet_name_generator_asp_net_core_api_rest_Dre_OS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetNameController : ControllerBase
    {
        public static List<string> SpecficNames = new List<string>();

        [HttpPost("/generate")]
        public ActionResult Post([FromQuery] AnimalType animalType, bool twopart)
        {
            Random Ran = new Random();

            switch (animalType)
            {
                case AnimalType.Dog:
                    SpecficNames = Names.DogName;
                    break;
                case AnimalType.Cat:
                    SpecficNames = Names.CatName;
                    break;
                case AnimalType.Bird:
                    SpecficNames = Names.BirdName;
                    break;
                default:
                    return BadRequest();
            }
            PetName petName = new PetName();

            petName.Name = SpecficNames[Ran.Next(0, SpecficNames.Count - 1)];
            if (twopart)
            {
                petName.Name += " " + SpecficNames[Ran.Next(0, SpecficNames.Count - 1)];
            }
            return Ok(petName);
        
        }
    }
}

