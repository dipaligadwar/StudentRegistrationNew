﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3615
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace StudentRegistration.Eligibility.DataSets {
    
    
    /// <summary>
    ///Represents a strongly typed in-memory cache of data.
    ///</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [global::System.Serializable()]
    [global::System.ComponentModel.DesignerCategoryAttribute("code")]
    [global::System.ComponentModel.ToolboxItem(true)]
    [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [global::System.Xml.Serialization.XmlRootAttribute("dsViewElgStatus")]
    [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class dsViewElgStatus : global::System.Data.DataSet {
        
        private dtViewElgStatusDataTable tabledtViewElgStatus;
        
        private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public dsViewElgStatus() {
            this.BeginInit();
            this.InitClass();
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected dsViewElgStatus(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
                if ((ds.Tables["dtViewElgStatus"] != null)) {
                    base.Tables.Add(new dtViewElgStatusDataTable(ds.Tables["dtViewElgStatus"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.Browsable(false)]
        [global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public dtViewElgStatusDataTable dtViewElgStatus {
            get {
                return this.tabledtViewElgStatus;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.BrowsableAttribute(true)]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override global::System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override global::System.Data.DataSet Clone() {
            dsViewElgStatus cln = ((dsViewElgStatus)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["dtViewElgStatus"] != null)) {
                    base.Tables.Add(new dtViewElgStatusDataTable(ds.Tables["dtViewElgStatus"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
            this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tabledtViewElgStatus = ((dtViewElgStatusDataTable)(base.Tables["dtViewElgStatus"]));
            if ((initTable == true)) {
                if ((this.tabledtViewElgStatus != null)) {
                    this.tabledtViewElgStatus.InitVars();
                }
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "dsViewElgStatus";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/dsViewElgStatus.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tabledtViewElgStatus = new dtViewElgStatusDataTable();
            base.Tables.Add(this.tabledtViewElgStatus);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializedtViewElgStatus() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, global::System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == global::System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
            dsViewElgStatus ds = new dsViewElgStatus();
            global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
            global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
            global::System.Xml.Schema.XmlSchemaAny any = new global::System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace)) {
                global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                try {
                    global::System.Xml.Schema.XmlSchema schema = null;
                    dsSchema.Write(s1);
                    for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                        schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                        s2.SetLength(0);
                        schema.Write(s2);
                        if ((s1.Length == s2.Length)) {
                            s1.Position = 0;
                            s2.Position = 0;
                            for (; ((s1.Position != s1.Length) 
                                        && (s1.ReadByte() == s2.ReadByte())); ) {
                                ;
                            }
                            if ((s1.Position == s1.Length)) {
                                return type;
                            }
                        }
                    }
                }
                finally {
                    if ((s1 != null)) {
                        s1.Close();
                    }
                    if ((s2 != null)) {
                        s2.Close();
                    }
                }
            }
            xs.Add(dsSchema);
            return type;
        }
        
        public delegate void dtViewElgStatusRowChangeEventHandler(object sender, dtViewElgStatusRowChangeEvent e);
        
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [global::System.Serializable()]
        [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class dtViewElgStatusDataTable : global::System.Data.DataTable, global::System.Collections.IEnumerable {
            
            private global::System.Data.DataColumn columnEligibility_Form_No;
            
            private global::System.Data.DataColumn columnStudentName;
            
            private global::System.Data.DataColumn columnPRN_Number;
            
            private global::System.Data.DataColumn columnEligibilityStatus;
            
            private global::System.Data.DataColumn columnRPV2PrevCrPrChStatus;
            
            private global::System.Data.DataColumn columnReason;
            
            private global::System.Data.DataColumn columnName_QualExamMarkSheet;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public dtViewElgStatusDataTable() {
                this.TableName = "dtViewElgStatus";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal dtViewElgStatusDataTable(global::System.Data.DataTable table) {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected dtViewElgStatusDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn Eligibility_Form_NoColumn {
                get {
                    return this.columnEligibility_Form_No;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn StudentNameColumn {
                get {
                    return this.columnStudentName;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn PRN_NumberColumn {
                get {
                    return this.columnPRN_Number;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn EligibilityStatusColumn {
                get {
                    return this.columnEligibilityStatus;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn RPV2PrevCrPrChStatusColumn {
                get {
                    return this.columnRPV2PrevCrPrChStatus;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn ReasonColumn {
                get {
                    return this.columnReason;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn Name_QualExamMarkSheetColumn {
                get {
                    return this.columnName_QualExamMarkSheet;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public dtViewElgStatusRow this[int index] {
                get {
                    return ((dtViewElgStatusRow)(this.Rows[index]));
                }
            }
            
            public event dtViewElgStatusRowChangeEventHandler dtViewElgStatusRowChanging;
            
            public event dtViewElgStatusRowChangeEventHandler dtViewElgStatusRowChanged;
            
            public event dtViewElgStatusRowChangeEventHandler dtViewElgStatusRowDeleting;
            
            public event dtViewElgStatusRowChangeEventHandler dtViewElgStatusRowDeleted;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AdddtViewElgStatusRow(dtViewElgStatusRow row) {
                this.Rows.Add(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public dtViewElgStatusRow AdddtViewElgStatusRow(string Eligibility_Form_No, string StudentName, string PRN_Number, string EligibilityStatus, string RPV2PrevCrPrChStatus, string Reason, string Name_QualExamMarkSheet) {
                dtViewElgStatusRow rowdtViewElgStatusRow = ((dtViewElgStatusRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        Eligibility_Form_No,
                        StudentName,
                        PRN_Number,
                        EligibilityStatus,
                        RPV2PrevCrPrChStatus,
                        Reason,
                        Name_QualExamMarkSheet};
                rowdtViewElgStatusRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowdtViewElgStatusRow);
                return rowdtViewElgStatusRow;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual global::System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override global::System.Data.DataTable Clone() {
                dtViewElgStatusDataTable cln = ((dtViewElgStatusDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataTable CreateInstance() {
                return new dtViewElgStatusDataTable();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnEligibility_Form_No = base.Columns["Eligibility_Form_No"];
                this.columnStudentName = base.Columns["StudentName"];
                this.columnPRN_Number = base.Columns["PRN_Number"];
                this.columnEligibilityStatus = base.Columns["EligibilityStatus"];
                this.columnRPV2PrevCrPrChStatus = base.Columns["RPV2PrevCrPrChStatus"];
                this.columnReason = base.Columns["Reason"];
                this.columnName_QualExamMarkSheet = base.Columns["Name_QualExamMarkSheet"];
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnEligibility_Form_No = new global::System.Data.DataColumn("Eligibility_Form_No", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnEligibility_Form_No);
                this.columnStudentName = new global::System.Data.DataColumn("StudentName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnStudentName);
                this.columnPRN_Number = new global::System.Data.DataColumn("PRN_Number", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnPRN_Number);
                this.columnEligibilityStatus = new global::System.Data.DataColumn("EligibilityStatus", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnEligibilityStatus);
                this.columnRPV2PrevCrPrChStatus = new global::System.Data.DataColumn("RPV2PrevCrPrChStatus", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnRPV2PrevCrPrChStatus);
                this.columnReason = new global::System.Data.DataColumn("Reason", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnReason);
                this.columnName_QualExamMarkSheet = new global::System.Data.DataColumn("Name_QualExamMarkSheet", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnName_QualExamMarkSheet);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public dtViewElgStatusRow NewdtViewElgStatusRow() {
                return ((dtViewElgStatusRow)(this.NewRow()));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder) {
                return new dtViewElgStatusRow(builder);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Type GetRowType() {
                return typeof(dtViewElgStatusRow);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.dtViewElgStatusRowChanged != null)) {
                    this.dtViewElgStatusRowChanged(this, new dtViewElgStatusRowChangeEvent(((dtViewElgStatusRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.dtViewElgStatusRowChanging != null)) {
                    this.dtViewElgStatusRowChanging(this, new dtViewElgStatusRowChangeEvent(((dtViewElgStatusRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.dtViewElgStatusRowDeleted != null)) {
                    this.dtViewElgStatusRowDeleted(this, new dtViewElgStatusRowChangeEvent(((dtViewElgStatusRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.dtViewElgStatusRowDeleting != null)) {
                    this.dtViewElgStatusRowDeleting(this, new dtViewElgStatusRowChangeEvent(((dtViewElgStatusRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemovedtViewElgStatusRow(dtViewElgStatusRow row) {
                this.Rows.Remove(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
                global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
                global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
                dsViewElgStatus ds = new dsViewElgStatus();
                global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "dtViewElgStatusDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace)) {
                    global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                    global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                    try {
                        global::System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                            schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length)) {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; ((s1.Position != s1.Length) 
                                            && (s1.ReadByte() == s2.ReadByte())); ) {
                                    ;
                                }
                                if ((s1.Position == s1.Length)) {
                                    return type;
                                }
                            }
                        }
                    }
                    finally {
                        if ((s1 != null)) {
                            s1.Close();
                        }
                        if ((s2 != null)) {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }
        }
        
        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class dtViewElgStatusRow : global::System.Data.DataRow {
            
            private dtViewElgStatusDataTable tabledtViewElgStatus;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal dtViewElgStatusRow(global::System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tabledtViewElgStatus = ((dtViewElgStatusDataTable)(this.Table));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Eligibility_Form_No {
                get {
                    try {
                        return ((string)(this[this.tabledtViewElgStatus.Eligibility_Form_NoColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'Eligibility_Form_No\' in table \'dtViewElgStatus\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tabledtViewElgStatus.Eligibility_Form_NoColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string StudentName {
                get {
                    try {
                        return ((string)(this[this.tabledtViewElgStatus.StudentNameColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'StudentName\' in table \'dtViewElgStatus\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tabledtViewElgStatus.StudentNameColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string PRN_Number {
                get {
                    try {
                        return ((string)(this[this.tabledtViewElgStatus.PRN_NumberColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'PRN_Number\' in table \'dtViewElgStatus\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tabledtViewElgStatus.PRN_NumberColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string EligibilityStatus {
                get {
                    try {
                        return ((string)(this[this.tabledtViewElgStatus.EligibilityStatusColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'EligibilityStatus\' in table \'dtViewElgStatus\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tabledtViewElgStatus.EligibilityStatusColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string RPV2PrevCrPrChStatus {
                get {
                    try {
                        return ((string)(this[this.tabledtViewElgStatus.RPV2PrevCrPrChStatusColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'RPV2PrevCrPrChStatus\' in table \'dtViewElgStatus\' is DBNull." +
                                "", e);
                    }
                }
                set {
                    this[this.tabledtViewElgStatus.RPV2PrevCrPrChStatusColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Reason {
                get {
                    try {
                        return ((string)(this[this.tabledtViewElgStatus.ReasonColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'Reason\' in table \'dtViewElgStatus\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tabledtViewElgStatus.ReasonColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Name_QualExamMarkSheet {
                get {
                    try {
                        return ((string)(this[this.tabledtViewElgStatus.Name_QualExamMarkSheetColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'Name_QualExamMarkSheet\' in table \'dtViewElgStatus\' is DBNul" +
                                "l.", e);
                    }
                }
                set {
                    this[this.tabledtViewElgStatus.Name_QualExamMarkSheetColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsEligibility_Form_NoNull() {
                return this.IsNull(this.tabledtViewElgStatus.Eligibility_Form_NoColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetEligibility_Form_NoNull() {
                this[this.tabledtViewElgStatus.Eligibility_Form_NoColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsStudentNameNull() {
                return this.IsNull(this.tabledtViewElgStatus.StudentNameColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetStudentNameNull() {
                this[this.tabledtViewElgStatus.StudentNameColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsPRN_NumberNull() {
                return this.IsNull(this.tabledtViewElgStatus.PRN_NumberColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetPRN_NumberNull() {
                this[this.tabledtViewElgStatus.PRN_NumberColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsEligibilityStatusNull() {
                return this.IsNull(this.tabledtViewElgStatus.EligibilityStatusColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetEligibilityStatusNull() {
                this[this.tabledtViewElgStatus.EligibilityStatusColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsRPV2PrevCrPrChStatusNull() {
                return this.IsNull(this.tabledtViewElgStatus.RPV2PrevCrPrChStatusColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetRPV2PrevCrPrChStatusNull() {
                this[this.tabledtViewElgStatus.RPV2PrevCrPrChStatusColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsReasonNull() {
                return this.IsNull(this.tabledtViewElgStatus.ReasonColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetReasonNull() {
                this[this.tabledtViewElgStatus.ReasonColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsName_QualExamMarkSheetNull() {
                return this.IsNull(this.tabledtViewElgStatus.Name_QualExamMarkSheetColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetName_QualExamMarkSheetNull() {
                this[this.tabledtViewElgStatus.Name_QualExamMarkSheetColumn] = global::System.Convert.DBNull;
            }
        }
        
        /// <summary>
        ///Row event argument class
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class dtViewElgStatusRowChangeEvent : global::System.EventArgs {
            
            private dtViewElgStatusRow eventRow;
            
            private global::System.Data.DataRowAction eventAction;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public dtViewElgStatusRowChangeEvent(dtViewElgStatusRow row, global::System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public dtViewElgStatusRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}

#pragma warning restore 1591