using GestaoDeDiretorios.Data;
using GestaoDeDiretorios.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestaoDeDiretorios.Controllers
{
    public class DiretoriosController : Controller
    {
        // GET: Diretorios
        private readonly AppDbContext _db = new AppDbContext();

        public ActionResult Index()
        {
            var diretorios = _db.Diretorios.ToList();

            return View(diretorios);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Diretorio diretorio)
        {
            if (ModelState.IsValid)
            {
                // Caminho do Diretorio
                var caminho = "~/Media/Users/" + diretorio.Nome;


                // Criar diretório Físico
                string folderFisico = Server.MapPath(caminho);
                diretorio.Caminho = folderFisico;
                

                if (!Directory.Exists(folderFisico))
                {
                    _db.Diretorios.Add(diretorio);
                    _db.SaveChanges();

                    Directory.CreateDirectory(folderFisico);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mensagem = "Já existe uma pasta criada com o mesmo nome no mesmo local!";
                }
            }

            return View();
        }


        public ActionResult Eliminar(int id)
        {
            var diretorio = _db.Diretorios.Find(id);
            return View(diretorio);
        }

        [HttpPost]
        public ActionResult Eliminar(Diretorio viewModel)
        {
            var diretorio = _db.Diretorios.Find(viewModel.Id);

            if (!Directory.Exists(diretorio.Caminho))
            {
                ViewBag.Mensagem = "Erro ao eliminar! O diretório não existe.";
                return View(diretorio);
            }
            else
            {
                Directory.Delete(diretorio.Caminho);

                _db.Diretorios.Remove(diretorio);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
}