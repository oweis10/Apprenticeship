using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Apprenticeship.Models;
using Apprenticeship.Models.Intermediate;
using Apprenticeship.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoreLinq;

namespace Apprenticeship.Controllers
{
    public class PlacementController : Controller
    {
        private IPlacementRepository _placementRepository;
        private IStudentRepository _studentRepository;
        private ISchoolMentorRepository _schoolMentorRepository;
        private IWorkMentorRepository _workMentorRepository;

        public PlacementController(IPlacementRepository placementRepository,
                                   IStudentRepository studentRepository,
                                   ISchoolMentorRepository schoolMentorRepositor,
                                   IWorkMentorRepository workMentorRepository)
        {
            _placementRepository = placementRepository;
            _studentRepository = studentRepository;
            _schoolMentorRepository = schoolMentorRepositor;
            _workMentorRepository = workMentorRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            dynamic placement = new ExpandoObject();
            try
            {
                placement.placements = _placementRepository.GetPlacements();
                return View(placement);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void FillListItems()
        {
            var stuednts = _studentRepository.GetStudents();
            List<SelectListItem> studentsList = new List<SelectListItem>();
            foreach (var student in stuednts)
            {
                studentsList.Add(new SelectListItem
                {
                    Text = student.FirstName + " " + student.SecondName + " " + student.LastName,
                    Value = student.Id.ToString()
                });
            }
            ViewBag.students = studentsList;

            ///////////

            var schoolMentors = _schoolMentorRepository.GetSchoolMentors();
            List<SelectListItem> schoolMentorsList = new List<SelectListItem>();
            foreach (var schoolMentor in schoolMentors)
            {
                schoolMentorsList.Add(new SelectListItem
                {
                    Text = schoolMentor.FirstName + " " + schoolMentor.SecondName + " " + schoolMentor.LastName,
                    Value = schoolMentor.Id.ToString()
                });
            }
            ViewBag.schoolMentors = schoolMentorsList;

            ///////////

            var workMentors = _workMentorRepository.GetWorkMentors();
            List<SelectListItem> workMentorsList = new List<SelectListItem>();
            foreach (var workMentor in workMentors)
            {
                workMentorsList.Add(new SelectListItem
                {
                    Text = workMentor.FirstName + " " + workMentor.SecondName + " " + workMentor.LastName,
                    Value = workMentor.Id.ToString()
                });
            }
            ViewBag.workMentors = workMentorsList;


            ///////////

            var noses = _placementRepository.GetNoses();
            List<SelectListItem> nosesList = new List<SelectListItem>();
            foreach (var nos in noses)
            {
                nosesList.Add(new SelectListItem
                {
                    Text = nos.Name,
                    Value = nos.Id.ToString()
                });
            }
            ViewBag.noses = nosesList;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            try
            {
                FillListItems();
                return View();
            }
            catch
            {
                return RedirectToAction("Index", "Placement");
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(IntermediatePlacement intermediatePlacement, List<long> Noses)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    long size = intermediatePlacement.portfolio.Sum(f => f.Length);

                    IntermediateFile intermediatPortFolioFile;
                    foreach (var formFile in intermediatePlacement.portfolio)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", formFile.FileName);
                        if (formFile.Length > 0)
                        {
                            Stream st = formFile.OpenReadStream();
                            using (BinaryReader br = new BinaryReader(st))
                            {
                                var byteFile = br.ReadBytes((int)st.Length);
                                intermediatPortFolioFile = new IntermediateFile()
                                {
                                    ContentType = formFile.ContentType,
                                    File = byteFile,
                                    Name = formFile.FileName
                                };

                            }
                            intermediatePlacement.portFolioFile = intermediatPortFolioFile;
                        }
                    }

                    var result = _placementRepository.InsertPlacement(intermediatePlacement, Noses);
                    if(result)
                    {
                        return RedirectToAction("Index", "Placement");
                    }
                    else
                    {
                        FillListItems();
                        ViewBag.errorMsg = "This student is already in another Placement";
                        return View(intermediatePlacement);
                    }
                    
                }
                else
                {
                    FillListItems();
                    return View(intermediatePlacement);
                }
                
            }
            catch
            {
                return RedirectToAction("Index", "Placement");
            }

        }

        [Authorize]
        public IActionResult EditView(long placementId)
        {
            try
            {
                var stuednts = _studentRepository.GetStudents();
                var schoolMentors = _schoolMentorRepository.GetSchoolMentors();
                var workMentors = _workMentorRepository.GetWorkMentors();
                var allNoses = _placementRepository.GetNoses();
                
                List<SelectListItem> nosesList = new List<SelectListItem>();
                List<SelectListItem> studentsList = new List<SelectListItem>();
                List<SelectListItem> schoolMentorsList = new List<SelectListItem>();
                List<SelectListItem> workMentorsList = new List<SelectListItem>();

                var interMediateplacement = _placementRepository.GetPlacement(placementId);
                var placementNoses = _placementRepository.GetPlacementNoses(placementId);

                foreach (var nos in placementNoses) 
                {
                    nosesList.Add(new SelectListItem
                    {
                        Text = nos.Name,
                        Value = nos.Id.ToString(),
                        Selected = true
                    });
                    allNoses.Remove(nos);
                }

                foreach(var nos in allNoses)
                {
                    nosesList.Add(new SelectListItem
                    {
                        Text = nos.Name,
                        Value = nos.Id.ToString(),
                        Selected = false
                    });
                }
                
                ViewBag.noses = nosesList.DistinctBy(x => x.Value);

                /////////

                foreach (var student in stuednts)
                {
                        if (student.Id == interMediateplacement.StudentId)
                        {
                            studentsList.Add(new SelectListItem
                            {
                                Text = interMediateplacement.StudentName,
                                Value = interMediateplacement.StudentId,
                                Selected = true
                            });
                            //break;
                        }
                        else
                        {
                        studentsList.Add(new SelectListItem
                            {
                            Text = student.FirstName+" "+student.SecondName+" " +student.LastName,
                            Value = student.Id,
                            Selected = false
                            });
                            //break;
                        }
                }

                ViewBag.students = studentsList;

                /////////

                foreach (var schoolMentor in schoolMentors)
                {
                        if (schoolMentor.Id == interMediateplacement.SchoolMentorId)
                        {
                            schoolMentorsList.Add(new SelectListItem
                            {
                                Text = interMediateplacement.SchoolMentorName,
                                Value = interMediateplacement.SchoolMentorId,
                                Selected = true
                            });
                            //break;
                        }
                        else
                        {
                        schoolMentorsList.Add(new SelectListItem
                            {
                            Text = schoolMentor.FirstName + " " + schoolMentor.SecondName + " " + schoolMentor.LastName,
                            Value = schoolMentor.Id,
                            Selected = false
                            });
                            //break;
                        }
                }

                ViewBag.schoolMentors = schoolMentorsList;

                /////////

                foreach (var workMentor in workMentors)
                {
                        if (workMentor.Id == interMediateplacement.WorkMentorId)
                        {
                            workMentorsList.Add(new SelectListItem
                            {
                                Text = interMediateplacement.WorkMentorName,
                                Value = interMediateplacement.WorkMentorId,
                                Selected = true
                            });
                            //break;
                        }
                        else
                        {
                            workMentorsList.Add(new SelectListItem
                            {
                                Text = workMentor.FirstName + " " + workMentor.SecondName + " " + workMentor.LastName,
                                Value = workMentor.Id,
                                Selected = false
                            });
                            //break;
                        }
                }

                ViewBag.workMentors = workMentorsList;

                return View(interMediateplacement);
            }
            catch(Exception e)
            {
                var msg = e.Message;
                    return RedirectToAction("Index", "Placement");
            }

        }

        [HttpPost]
        [Authorize]
        public IActionResult EditView(IntermediatePlacement intermediatePlacement, List<long> Noses)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    long size = intermediatePlacement.portfolio.Sum(f => f.Length);

                    IntermediateFile intermediatPortFolioFile;
                    foreach (var formFile in intermediatePlacement.portfolio)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", formFile.FileName);
                        if (formFile.Length > 0)
                        {
                            Stream st = formFile.OpenReadStream();
                            using (BinaryReader br = new BinaryReader(st))
                            {
                                var byteFile = br.ReadBytes((int)st.Length);
                                intermediatPortFolioFile = new IntermediateFile()
                                {
                                    ContentType = formFile.ContentType,
                                    File = byteFile,
                                    Name = formFile.FileName
                                };

                            }
                            intermediatePlacement.portFolioFile = intermediatPortFolioFile;
                        }
                    }
                    _placementRepository.UpdatePlacement(intermediatePlacement, Noses);
                    return RedirectToAction("Index", "Placement");
                }
                else
                {
                    FillListItems();
                    return View(intermediatePlacement);
                }

            }
            catch
            {
                return RedirectToAction("Index", "Placement");
            }

        }
        public IActionResult Delete(long placementId)
        {
            _placementRepository.DeletePlacement(placementId);
            return RedirectToAction("Index", "Placement");
        }
    }
}