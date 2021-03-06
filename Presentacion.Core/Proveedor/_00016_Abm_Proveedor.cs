namespace Presentacion.Core.Proveedor
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Aplicacion.Constantes;
    using IServicio.CondicionIva.DTOs;
    using IServicio.Departamento;
    using IServicio.Departamento.DTOs;
    using IServicio.Localidad;
    using IServicio.Localidad.DTOs;
    using IServicio.Persona;
    using IServicio.Persona.DTOs;
    using IServicio.Provincia;
    using IServicio.Provincia.DTOs;
    using Presentacion.Core.CondicionIva;
    using Presentacion.Core.Departamento;
    using Presentacion.Core.Localidad;
    using Presentacion.Core.Provincia;
    using PresentacionBase.Formularios;
    using StructureMap;

    public partial class _00016_Abm_Proveedor : FormAbm
    {
        private readonly IProveedorServicio _servicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IDepartamentoServicio _departamentoServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly ICondicionIvaServicio _condicionIvaServicio;
        private readonly Validar Validar;

        public _00016_Abm_Proveedor(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _servicio = ObjectFactory.GetInstance<IProveedorServicio>();
            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _departamentoServicio = ObjectFactory.GetInstance<IDepartamentoServicio>();
            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
            _condicionIvaServicio = ObjectFactory.GetInstance<ICondicionIvaServicio>();
            Validar = new Validar();
        }

        private void _00016_Abm_Proveedor_Load(object sender, System.EventArgs e)
        {
            Validar.ComoAlfanumerico(txtRazonSocial, true);
            Validar.ComoCuit(txtCUIT, true);
            Validar.ComoDomicilio(txtDomicilio, true);
            Validar.ComoMail(txtMail, true);
            Validar.ComoTelefono(txtTelefono);

            // Cargar Combos
            ActualizarCondicionIva();
            ActualizarProvincia();
            ActualizarDepartamento();
            ActualizarLocalidad();

            if (EntidadId.HasValue)
            {
                var proveedor = (ProveedorDto)_servicio.Obtener(EntidadId.Value);

                if (proveedor == null)
                {
                    MessageBox.Show("Ocurrio un error al obtener el registro seleccionado.");
                    Close();
                }

                // Cargar Datos en controles
                var localidad = (LocalidadDto)_localidadServicio.Obtener(proveedor.LocalidadId);

                txtRazonSocial.Text = proveedor.RazonSocial;
                txtCUIT.Text = proveedor.CUIT;
                txtTelefono.Text = proveedor.Telefono;
                txtDomicilio.Text = proveedor.Direccion;
                txtMail.Text = proveedor.Mail;

                ActualizarCondicionIva(proveedor.CondicionIvaId);
                cmbCondicionIva.SelectedValue = proveedor.CondicionIvaId;

                ActualizarProvincia(localidad.ProvinciaId);
                cmbProvincia.SelectedValue = localidad.ProvinciaId;

                ActualizarDepartamento(localidad.DepartamentoId);
                cmbDepartamento.SelectedValue = localidad.DepartamentoId;

                ActualizarLocalidad(localidad.Id);
                cmbLocalidad.SelectedValue = localidad.Id;

            }
        }

        private void ActualizarCondicionIva(long idEntidad = 0)
        {
            var lstCondicionesIva = _condicionIvaServicio.Obtener(string.Empty, false)
                .Select(x => (CondicionIvaDto)x)
                .ToList();

            if (idEntidad != 0)
            {
                CondicionIvaDto condicionIva = (CondicionIvaDto)_condicionIvaServicio.Obtener(idEntidad);
                lstCondicionesIva.Add(condicionIva);
            }

            PoblarComboBox(cmbCondicionIva, lstCondicionesIva, "Descripcion", "Id");
        }

        public override bool VerificarDatosObligatorios()
        {
            bool ok = ValidateChildren();

            if (cmbProvincia.SelectedValue == null)
            {
                Validar.SetErrorProvider(cmbProvincia, "Seleccionar una provincia.");
                ok = false;
            }
            else Validar.ClearErrorProvider(cmbProvincia);

            if (cmbDepartamento.SelectedValue == null)
            {
                Validar.SetErrorProvider(cmbDepartamento, "Seleccionar un departamento.");
                ok = false;
            }
            else Validar.ClearErrorProvider(cmbDepartamento);

            if (cmbLocalidad.SelectedValue == null)
            {
                Validar.SetErrorProvider(cmbLocalidad, "Seleccionar una localidad.");
                ok = false;
            }
            else Validar.ClearErrorProvider(cmbLocalidad);

            return ok;
        }

        public override bool VerificarSiExiste(long? id = null)
        {
            return _servicio.VerificarSiExisteCuit(txtCUIT.Text, id);
        }

        // --- Acciones de botones
        public override void EjecutarComandoNuevo()
        {
            var nuevoRegistro = new ProveedorDto();
            nuevoRegistro.RazonSocial = txtRazonSocial.Text;
            nuevoRegistro.CUIT = txtCUIT.Text;
            nuevoRegistro.Telefono = txtTelefono.Text;
            nuevoRegistro.Direccion = txtDomicilio.Text;
            nuevoRegistro.Mail = txtMail.Text;
            nuevoRegistro.LocalidadId = (long)cmbLocalidad.SelectedValue;
            nuevoRegistro.CondicionIvaId = (long)cmbCondicionIva.SelectedValue;

            _servicio.Insertar(nuevoRegistro);
        }

        public override void EjecutarComandoModificar()
        {
            var modificarRegistro = new ProveedorDto();
            modificarRegistro.Id = (long)EntidadId;
            modificarRegistro.RazonSocial = txtRazonSocial.Text;
            modificarRegistro.CUIT = txtCUIT.Text;
            modificarRegistro.Telefono = txtTelefono.Text;
            modificarRegistro.Direccion = txtDomicilio.Text;
            modificarRegistro.Mail = txtMail.Text;
            modificarRegistro.LocalidadId = (long)cmbLocalidad.SelectedValue;
            modificarRegistro.CondicionIvaId = (long)cmbCondicionIva.SelectedValue;

            _servicio.Modificar(modificarRegistro);
        }

        public override void EjecutarComandoEliminar()
        {
            _servicio.Eliminar(EntidadId.Value);
        }

        public override void LimpiarControles(object obj, bool tieneValorAsociado = false)
        {
            base.LimpiarControles(obj);

            txtRazonSocial.Focus();
        }

        private void btnNuevaProvincia_Click(object sender, System.EventArgs e)
        {
            var form = new _00002_Abm_Provincia(TipoOperacion.Nuevo);
            form.ShowDialog();

            if (!form.RealizoAlgunaOperacion)
                return;

            ActualizarProvincia();
            ActualizarDepartamento();
            ActualizarLocalidad();
        }

        private void btnNuevoDepartamento_Click(object sender, System.EventArgs e)
        {
            var form = new _00004_Abm_Departamento(TipoOperacion.Nuevo);
            form.ShowDialog();

            if (!form.RealizoAlgunaOperacion)
                return;

            ActualizarProvincia((long)cmbProvincia.SelectedValue);
        }

        private void btnNuevaLocalidad_Click(object sender, System.EventArgs e)
        {
            var form = new _00006_AbmLocalidad(TipoOperacion.Nuevo);
            form.ShowDialog();

            if (!form.RealizoAlgunaOperacion)
                return;

            ActualizarDepartamento((long)cmbDepartamento.SelectedValue);
        }

        private void btnNuevaCondicionIva_Click(object sender, System.EventArgs e)
        {
            var form = new _00014_Abm_CondicionIva(TipoOperacion.Nuevo);
            form.ShowDialog();

            if (!form.RealizoAlgunaOperacion)
                return;

            PoblarComboBox(
                cmbCondicionIva,
                _condicionIvaServicio.Obtener(string.Empty, false),
                "Descripcion",
                "Id"
                );
        }

        // --- SELECCION DE LOCALIDAD
        private void cmbProvincia_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            ActualizarDepartamento();
            ActualizarLocalidad();
        }

        private void cmbDepartamento_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            ActualizarLocalidad();
        }

        private void ActualizarProvincia(long id = 0)
        {
            var lstProvincias = _provinciaServicio.Obtener(string.Empty, false)
                .Select(x => (ProvinciaDto)x)
                .OrderBy(x => x.Descripcion)
                .ToList();

            if (id != 0)
            {
                ProvinciaDto provincia = (ProvinciaDto)_provinciaServicio.Obtener(id);

                if(provincia.Eliminado)
                    lstProvincias.Add(provincia);
            }

            PoblarComboBox(cmbProvincia, lstProvincias, "Descripcion", "Id");
        }

        private void ActualizarDepartamento(long id = 0)
        {
            if (cmbProvincia.Items.Count < 1)
            {
                cmbDepartamento.DataSource = new List<DepartamentoDto>();
                return;
            }

            var lstDepartamentos = _departamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue)
                .Select(x => (DepartamentoDto)x)
                .OrderBy(x => x.Descripcion)
                .ToList();

            if (id != 0)
            {
                DepartamentoDto departamento = (DepartamentoDto)_departamentoServicio.Obtener(id);

                if(departamento.Eliminado)
                    lstDepartamentos.Add(departamento);
            }

            PoblarComboBox(cmbDepartamento, lstDepartamentos, "Descripcion", "Id");
        }

        private void ActualizarLocalidad(long id = 0)
        {
            if (cmbDepartamento.Items.Count < 1)
            {
                cmbLocalidad.DataSource = new List<LocalidadDto>();
                return;
            }

            var lstLocalidads = _localidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue)
                .Select(x => (LocalidadDto)x)
                .OrderBy(x => x.Descripcion)
                .ToList();

            if (id != 0)
            {
                LocalidadDto localidad = (LocalidadDto)_localidadServicio.Obtener(id);

                if(localidad.Eliminado)
                    lstLocalidads.Add(localidad);
            }

            PoblarComboBox(cmbLocalidad, lstLocalidads, "Descripcion", "Id");
        }

    }
}
